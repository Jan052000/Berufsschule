using System;
using System.Reflection;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Liegeplatzverwaltung.DataBaseUtils.Attributes;
using Liegeplatzverwaltung.DataBaseObjects;
using Liegeplatzverwaltung.DataBaseUtils;
using Liegeplatzverwaltung.FrontendConnection;
using System.Diagnostics;

namespace Liegeplatzverwaltung.Extensions
{
	public static class DbProjectRequests
	{
		public static List<(long ID, string Name)> GetAllPossibleLiegeplätze(int length, int width, int depth)
		{
			List<(long ID, string Name)> result = new List<(long ID, string Name)>();
			using SQLiteConnection conn = new SQLiteConnection(MainForm.ConnectionString);
			conn.Open();
			using (SQLiteCommand cmd = conn.CreateCommand())
			{
				cmd.CommandText = $"SELECT {GetColumnName<Liegeplatz>("ID")}, {GetColumnName<Liegeplatz>("Name")} FROM {DbUtils.GetTableName<Liegeplatz>()} WHERE\n" +
					$"{GetColumnName<Liegeplatz>("Depth")}>={depth} AND\n" +
					$"{GetColumnName<Liegeplatz>("Width")}>={width} AND\n" +
					$"{GetColumnName<Liegeplatz>("Length")}>={length} AND\n" +
					$"({GetColumnName<Liegeplatz>("YachtID")}='' OR {GetColumnName<Liegeplatz>("YachtID")} is NULL)";
				using SQLiteDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Liegeplatz temp = DbBaseClass.Serialize<Liegeplatz>(reader);
					result.Add((temp.ID!, temp.Name!));
				}
			}

			return result;
		}

		private static string GetColumnName<T>(string propertyName)
		{
			if (typeof(T).GetProperties().First(prop => prop.Name == propertyName)?.GetCustomAttribute<ColumnAttribute>() is ColumnAttribute attr)
			{
				return attr.ColumnName;
			}
			throw new ArgumentException($"Property not found {propertyName}");
		}

		public static void UpdateLiegeplatzGeparkt(long liegeplatzID, ResponseObject yacht)
		{
			//Create connection
			using SQLiteConnection conn = new SQLiteConnection(MainForm.ConnectionString);
			conn.Open();
			Yacht? assigned = null;
			//Check if yacht is in database
			using (SQLiteCommand cmd = conn.CreateCommand())
			{
				string primCol = GetColumnName<Yacht>("ID");
				cmd.CommandText = $"SELECT {primCol} FROM {DbUtils.GetTableName<Yacht>()} WHERE {primCol}='{yacht.ShipUUID}'";
				using (SQLiteDataReader reader = cmd.ExecuteReader())
				{
					if (reader.Read())
						assigned = DbBaseClass.Serialize<Yacht>(reader);
				}
			}
			//If it is not..
			if (assigned is null)
			{
				Besitzer owner = null;
				//Check if owner is in database
				using (SQLiteCommand cmd = conn.CreateCommand())
				{
					string primColName = GetColumnName<Besitzer>("ID");
					string mailCol = GetColumnName<Besitzer>("EMail");
					cmd.CommandText = $"SELECT {primColName}, {mailCol} FROM {DbUtils.GetTableName<Besitzer>()} WHERE {mailCol}='{yacht.EMail}'";
					using (SQLiteDataReader reader = cmd.ExecuteReader())
					{
						if (reader.Read())
							owner = DbBaseClass.Serialize<Besitzer>(reader);
					}
				}
				//If not..
				if (owner is null)
				{
					//Add it and create owner
					using (SQLiteCommand cmd = conn.CreateCommand())
					{
						owner = new Besitzer()
						{
							EMail = yacht.EMail
						};
						cmd.CommandText = DbUtils.GetFillTableWithDataCommand(new List<Besitzer>() { owner }, new SQLiteDialect());
						cmd.ExecuteNonQuery();
						owner.ID = conn.LastInsertRowId;
					}
				}

				//Add new yacht
				using (SQLiteCommand cmd = conn.CreateCommand())
				{
					assigned = new Yacht()
					{
						Depth = yacht.Depth,
						ID = yacht.ShipUUID,
						Length = yacht.Length,
						OwnerID = owner.ID,
						ShipType = yacht.Type,
						Width = yacht.Width
					};
					cmd.CommandText = DbUtils.GetFillTableWithDataCommand(new List<Yacht>() { assigned }, new SQLiteDialect());
					cmd.ExecuteNonQuery();
				}
			}

			//Update liegeplatz yacht
			using (SQLiteCommand cmd = conn.CreateCommand())
			{
				cmd.CommandText = $"UPDATE {DbUtils.GetTableName<Liegeplatz>()} SET {GetColumnName<Liegeplatz>("YachtID")}='{yacht.ShipUUID}' WHERE {GetColumnName<Liegeplatz>("ID")}={liegeplatzID}";
				cmd.ExecuteNonQuery();
			}
		}
	}
}
