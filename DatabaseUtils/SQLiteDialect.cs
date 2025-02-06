namespace DataBaseUtils
{
	public class SQLiteDialect : IDbTypeSwitch
	{
		public string AutoIncrementString { get => "AUTOINCREMENT"; }

		public string InLinePrimaryKeyString => "PRIMARY KEY";

		public string RequiredString => "NOT NULL";

		private Dictionary<Type, string> TypeSwitch { get; } = new Dictionary<Type, string>()
		{
			{ typeof(string), "TEXT" },
			{ typeof(Enum), "TEXT" },
			{ typeof(byte[]), "BLOB" },
			{ typeof(DateTime), "DATE" },
			{ typeof(DateTime?), "DATE" },
			{ typeof(long), "INTEGER" },
			{ typeof(long?), "INTEGER" },
			{ typeof(int), "INTEGER" },
			{ typeof(int?), "INTEGER" },
			{ typeof(float), "REAL" },
			{ typeof(float?), "REAL" },
			{ typeof(decimal), "REAL" },
			{ typeof(decimal?), "REAL" },
			{ typeof(double), "REAL" },
			{ typeof(double?), "REAL" },
		};

		public string FormatValue(object? value)
		{
			switch (value)
			{
				case null:
					return "null";
				case string:
					if ((string)value == "")
						return "''";
					return $"'{value}'";
				case byte[] img:
					string res = "";
					string file = BitConverter.ToString(img, 0);
					if (file == "")
						res += "''";
					else
						res += $"'{file}'";

					return res;
				case Enum:
					return $"'{Enum.GetName(value.GetType(), value)}'";
				case int:
				case long:
					return value.ToString() ?? "null";
				case float:
				case decimal:
				case double:
					return Convert.ToString(value, System.Globalization.CultureInfo.InvariantCulture) ?? "null";
				case DateTime dt:
					return $"'{dt:yyyy-MM-dd HH:mm:ss.fff}'";
				default:
					return $"'{(value.ToString() ?? "")}'";
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
