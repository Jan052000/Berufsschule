using Liegeplatzverwaltung.DataBaseUtils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Liegeplatzverwaltung
{
	internal class SQLiteDialect : IDbTypeSwitch
	{
		public string AutoIncrementString { get => "AUTOINCREMENT"; }

		public string InLinePrimaryKeyString => "PRIMARY KEY";

		private Dictionary<Type, string> TypeSwitch { get; } = new Dictionary<Type, string>()
		{
			{ typeof(string), "TEXT" },
			{ typeof(long), "INTEGER" },
			{ typeof(DateTime), "DATE" },
			{ typeof(byte[]), "BLOB" },
			{ typeof(long?), "INTEGER" },
			{ typeof(DateTime?), "DATE" },
		};

		public string FormatValue(object? value, Type valueType)
		{
			switch (value)
			{
				case string:
					return $"'{value}'";
				case byte[] img:
					string res = "";
					string file = BitConverter.ToString((byte[])value, 0);
					if (file == "")
						res += "''";
					else
						res += $"'{file}'";

					return res;
				default:
					if (value is null)
					{
						return "null";
					}
					return value?.ToString();
			}
		}

		object? SwitchDefault(Type type)
		{
			if (type == typeof(long) || type == typeof(int) || type == typeof(double) || type == typeof(decimal))
				return -1;
			if (type == typeof(string))
				return "''";
			if (type == typeof(DateTime))
				return new DateTime();
			if (type == typeof(byte[]))
				return new byte[0];

			if (type == typeof(long?) || type == typeof(int?) || type == typeof(double?) || type == typeof(decimal?))
				return -1;
			if (type == typeof(DateTime?))
				return new DateTime();

			return null;
		}

		public string GetDBType(Type type)
		{
			if (!TypeSwitch.ContainsKey(type))
				return "TEXT";
			return TypeSwitch[type];
		}
	}
}
