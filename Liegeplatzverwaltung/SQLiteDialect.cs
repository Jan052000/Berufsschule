using Liegeplatzverwaltung.DataBaseUtils;

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

		public string FormatValue(object? value)
		{
			switch (value)
			{
				case null:
					return "null";
				case string:
					return $"'{value}'";
				case byte[] img:
					string res = "";
					string file = BitConverter.ToString(img, 0);
					if (file == "")
						res += "''";
					else
						res += $"'{file}'";

					return res;
				default:
					return value.ToString() ?? "''";
			}
		}

		public string GetDBType(Type type)
		{
			if (!TypeSwitch.ContainsKey(type))
				return "TEXT";
			return TypeSwitch[type];
		}
	}
}
