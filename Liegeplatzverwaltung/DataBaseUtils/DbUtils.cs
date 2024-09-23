using Liegeplatzverwaltung.DataBaseObjects;
using Liegeplatzverwaltung.DataBaseUtils.Attributes;
using System.Reflection;

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
			List<string> result = typeof(T).GetProperties().Where(prop => prop.GetCustomAttribute<ColumnAttribute>() != null && !(prop.GetCustomAttribute<PrimaryKeyAttribute>()?.AutoIncrement).GetValueOrDefault())
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
			List<string> commandParts = new List<string>() { $"CREATE TABLE{(ifNotExists ? " IF NOT EXISTS" : "")} {GetTableName<T>()} (" };
			List<PropertyInfo> primaryKeys = typeof(T).GetProperties().Where(prop => prop.GetCustomAttribute<PrimaryKeyAttribute>() is not null).ToList();
			List<PropertyInfo> foreignKeys = typeof(T).GetProperties().Where(prop => prop.GetCustomAttribute<ForeignKeyAttribute>() is not null).ToList();
			List<PropertyInfo> properties = typeof(T).GetProperties().Where(prop => prop.GetCustomAttribute<ColumnAttribute>() is not null and not PrimaryKeyAttribute and not ForeignKeyAttribute).ToList();

			List<string> columns = new List<string>();

			switch (primaryKeys.Count)
			{
				case int count when count == 1:
					PrimaryKeyAttribute pattr = primaryKeys[0].GetCustomAttribute<PrimaryKeyAttribute>()!;
					columns.Add($"{pattr.ColumnName} {typeDialect.GetDBType(primaryKeys[0].PropertyType)} {typeDialect.InLinePrimaryKeyString}{((pattr.AutoIncrement ? $" {typeDialect.AutoIncrementString}" : ""))}");
					break;
				case int count when count > 1:
					List<string> primarys = new List<string>();
					primaryKeys.ForEach(prop =>
					{
						PrimaryKeyAttribute pattr = prop.GetCustomAttribute<PrimaryKeyAttribute>()!;
						primarys.Add(pattr.ColumnName);
						columns.Add($"{pattr.ColumnName} {typeDialect.GetDBType(prop.PropertyType)}");
					});
					columns.Add($"\nPRIMARY KEY ({String.Join(",", primarys)})");
					break;
			}

			foreignKeys.ForEach(prop =>
			{
				ForeignKeyAttribute attr = prop.GetCustomAttribute<ForeignKeyAttribute>()!;
				columns.Add($"{attr.ColumnName} {typeDialect.GetDBType(prop.PropertyType)}");
			});

			properties.ForEach(prop =>
			{
				columns.Add($"{prop.GetCustomAttribute<ColumnAttribute>()!.ColumnName} {typeDialect.GetDBType(prop.PropertyType)}");
			});

			foreignKeys.ForEach(prop =>
			{
				ForeignKeyAttribute attr = prop.GetCustomAttribute<ForeignKeyAttribute>()!;
				columns.Add($"FOREIGN KEY ({attr.ColumnName}) REFERENCES {attr.ReferencedTable}({attr.ReferencedColumn})");
			});
			commandParts.Add(String.Join(",\n", columns));

			commandParts.Add(");");
			return String.Join("\n", commandParts);
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
					if (property.GetCustomAttribute<PrimaryKeyAttribute>()?.AutoIncrement is bool b && b)
						continue;
					value += dialect.FormatValue(property.GetValue(item)) + ",";
				}
				value = value.Substring(0, value.Length - 1) + ")";
				values.Add(value);
			}
			return command + String.Join(",\n", values.ToArray());
		}

		public static string GetUpdateStatusCommand(Liegeplatz platz, int newStatus)
		{
			return $"UPDATE {GetTableName(platz)} SET Status={newStatus} WHERE ID={platz.ID}";
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

		/// <summary>
		/// Generates a command to get all rows from a table defined in <typeparamref name="T"/>
		/// </summary>
		/// <typeparam name="T"><see cref="Type"/> to grab <see cref="TableAttribute"/> from</typeparam>
		/// <returns>Get command</returns>
		public static string GetGetAllCommand<T>() where T : class
		{
			return $"SELECT * FROM {GetTableName<T>()}";
		}

		/// <summary>
		/// Generates a command to delete a <see cref="List{T}"/> of items from their table
		/// </summary>
		/// <typeparam name="T"><see cref="Type"/> to grab <see cref="TableAttribute"/> from</typeparam>
		/// <param name="toDelete"><see cref="List{T}"/> of items to delete</param>
		/// <param name="dialect"><see cref="IDbTypeSwitch"/> to use for formatting values</param>
		/// <returns>Delete command</returns>
		public static string GetDeleteCommand<T>(List<T> toDelete, IDbTypeSwitch dialect) where T : class
		{
			string command = $"DELETE FROM {GetTableName<T>()}\nWHERE\n";

			List<string> wheres = new List<string>();
			List<PropertyInfo> primaryKeys = typeof(T).GetProperties().Where(prop => prop.GetCustomAttribute<PrimaryKeyAttribute>() is not null).ToList();
			foreach (T item in toDelete)
			{
				List<string> clauses = new List<string>();

				foreach (PropertyInfo property in primaryKeys)
				{
					clauses.Add($"{property.GetCustomAttribute<PrimaryKeyAttribute>()!.ColumnName}={dialect.FormatValue(property.GetValue(item))}");
				}

				wheres.Add($"({String.Join("AND\n", clauses)})");
			}
			command += String.Join("OR\n", wheres);

			return command;
		}
	}
}
