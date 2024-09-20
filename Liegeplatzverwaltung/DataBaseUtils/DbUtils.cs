using Liegeplatzverwaltung.DataBaseObjects;
using Liegeplatzverwaltung.DataBaseUtils.Attributes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Liegeplatzverwaltung.DataBaseUtils
{
	public class DbUtils
	{
		/// <summary>
		/// Gets table name from <typeparamref name="T"/>
		/// </summary>
		/// <typeparam name="T">Class to get table name of</typeparam>
		/// <returns>Tablename</returns>
		/// <exception cref="Exception"></exception>
		public static string GetTableName<T>() where T : class
		{
			string? tableName = typeof(T).GetCustomAttribute<TableAttribute>()?.TableName;
			if (tableName is not null)
				return tableName;
			throw new Exception($"No table name was defined for type {typeof(T).Name}");
		}

		/// <summary>
		/// Gets table name from <paramref name="tableClass"/>
		/// </summary>
		/// <param name="tableClass">Class to get table name of</param>
		/// <returns>Table name of <paramref name="tableClass"/></returns>
		/// <exception cref="Exception"></exception>
		public static string GetTableName(DbBaseClass tableClass)
		{
			string? tableName = tableClass.GetType().GetCustomAttribute<TableAttribute>()?.TableName;
			if (tableName is not null)
				return tableName;
			throw new Exception($"No table name was defined for type {tableClass.GetType().Name}");
		}

		/// <summary>
		/// Gets table nam for <see cref="Type"/> <paramref name="type"/>
		/// </summary>
		/// <param name="type"><see cref="Type"/> to get table name for</param>
		/// <returns>Table name of <paramref name="type"/></returns>
		/// <exception cref="Exception"></exception>
		public static string GetTableName(Type type)
		{
			string tableName = type.GetCustomAttribute<TableAttribute>()?.TableName!;
			if (tableName is not null)
				return tableName;
			throw new Exception($"No table name was defined for type {type.Name}");
		}

		/// <summary>
		/// Gets all columns in table for class <typeparamref name="T"/>
		/// </summary>
		/// <typeparam name="T">Table to get all columns for</typeparam>
		/// <returns><see cref="List{string}"/> of column names</returns>
		public static List<string> GetColumnNames<T>() where T : class
		{
			List<string> result = typeof(T).GetProperties().Where(prop => prop.GetCustomAttribute<ColumnAttribute>() != null)
				.Select(item => item.GetCustomAttribute<ColumnAttribute>()!.ColumnName).ToList();
			return result;
		}

		/// <summary>
		/// Generates a create command for table represented by <typeparamref name="T"/>
		/// </summary>
		/// <typeparam name="T">Type to generate create table command for</typeparam>
		/// <param name="typeDialect"><see cref="IDbTypeSwitch"/> to resolve types in command</param>
		/// <param name="ifNotExists">Wether or not command should have IF NOT EXISTS</param>
		/// <returns>Command to create a table for <typeparamref name="T"/></returns>
		/// <exception cref="Exception"></exception>
		public static string GetCreateCommand<T>(IDbTypeSwitch typeDialect, bool ifNotExists = true) where T : class
		{
			List<string> commandParts = new List<string>();
			string createCommand = $"CREATE TABLE {(ifNotExists ? "IF NOT EXISTS" : "")} {GetTableName<T>()} (\n";

			List<PropertyInfo> properties = typeof(T).GetProperties().ToList().Where(prop =>
			{
				return prop.GetCustomAttribute<ColumnAttribute>() != null;
			}).ToList();

			if (properties.Count == 0)
				throw new Exception($"No columns were found on type {typeof(T).Name}");

			properties.ForEach(prop =>
			{
				commandParts.Add($"{prop.GetCustomAttribute<ColumnAttribute>()!.ColumnName} {typeDialect.GetDBType(prop.PropertyType)}");
			});

			List<PropertyInfo> primaryKeys = typeof(T).GetProperties().ToList().Where(prop =>
			{
				return prop.GetCustomAttribute<PrimaryKeyAttribute>() != null;
			}).ToList();

			List<string> primarys = new List<string>();
			primaryKeys.ForEach(prop =>
			{
				primarys.Add(prop.GetCustomAttribute<PrimaryKeyAttribute>()!.ColumnName);
			});
			commandParts.Add($"\nPRIMARY KEY ({String.Join(",", primarys)})");

			List<PropertyInfo> foreignKeys = typeof(T).GetProperties().ToList().Where(prop =>
			{
				return prop.GetCustomAttribute<ForeignKeyAttribute>() != null;
			}).ToList();

			foreignKeys.ForEach(prop =>
			{
				ForeignKeyAttribute attr = prop.GetCustomAttribute<ForeignKeyAttribute>()!;
				commandParts.Add($"FOREIGN KEY ({attr.ColumnName}) REFERENCES {attr.ReferencedTable}({attr.ReferencedColumn})");
			});
			createCommand += String.Join(",", commandParts);

			createCommand += ")";
			return createCommand;
		}

		/// <summary>
		/// Fills a the table form <typeparamref name="T"/> with data from <paramref name="objects"/>
		/// </summary>
		/// <typeparam name="T">Class to fill table of</typeparam>
		/// <param name="objects"><see cref="List{T}"/> of objects to add to table</param>
		/// <returns>Insert command for table</returns>
		/// <exception cref="Exception"></exception>
		public static string GetFillTableWithDataCommand<T>(List<T> objects, IDbTypeSwitch dialect) where T : class
		{
			string command = $"INSERT INTO {GetTableName<T>()} ({String.Join(",", GetColumnNames<T>())})\nVALUES\n";
			List<string> values = new List<string>();
			foreach (var item in objects)
			{
				if (item is not T)
					throw new Exception($"Objects of type {item.GetType().Name} can not be put in table {GetTableName<T>()}");
				List<PropertyInfo> properties = item.GetType().GetProperties().Where(prop =>
					prop.GetCustomAttribute<ColumnAttribute>() != null
					).ToList();
				if (properties.Count == 0)
					throw new Exception($"No columns found on type {item.GetType().Name}");
				string value = "(";
				foreach (var property in properties)
				{
					value += dialect.FormatValue(property.GetValue(item)) + ",";
				}
				value = value.Substring(0, value.Length - 1) + ")";
				values.Add(value);
			}
			return command + String.Join(",\n", values.ToArray());
		}

		/// <summary>
		/// Updates a single row where all primary keys match <paramref name="updatedRow"/>
		/// </summary>
		/// <param name="updatedRow"><see cref="DbBaseClass"/> object to update row of</param>
		/// <returns>Command for row update</returns>
		public static string GetUpdateRowCommand(DbBaseClass updatedRow, IDbTypeSwitch dialect)
		{
			List<string> command = new List<string>()
			{
				$"UPDATE {GetTableName(updatedRow)}\nSET\n"
			};
			List<PropertyInfo> properties = updatedRow.GetType().GetProperties()
				.Where(prop => prop.GetCustomAttribute<ColumnAttribute>() is not null and not PrimaryKeyAttribute).ToList();

			List<string> values = new List<string>();
			foreach (PropertyInfo property in properties)
			{
				ColumnAttribute attr = property.GetCustomAttribute<ColumnAttribute>()!;
				values.Add($"{attr.ColumnName}={dialect.FormatValue(property.GetValue(updatedRow))}");
			}
			command.Add(String.Join(",\n", values));

			List<string> wheres = new List<string>();
			List<PropertyInfo> primaryKeys = updatedRow.GetType().GetProperties()
				.Where(prop => prop.GetCustomAttribute<PrimaryKeyAttribute>() != null).ToList();
			foreach (PropertyInfo property in primaryKeys)
			{
				wheres.Add($"{property.GetCustomAttribute<PrimaryKeyAttribute>()!.ColumnName}={dialect.FormatValue(property.GetValue(updatedRow))}");
			}
			command.Add("WHERE");
			command.Add(String.Join(",\n", wheres));
			return String.Join("\n", command);
		}
	}
}
