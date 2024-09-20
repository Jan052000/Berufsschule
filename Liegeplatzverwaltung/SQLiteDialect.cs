using Liegeplatzverwaltung.DataBaseUtils;
using System;
using System.Collections.Generic;
using System.Linq;
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
			{ typeof(int), "INTEGER" },
			{ typeof(DateTime), "DATE" },
			{ typeof(byte[]), "BLOB" },
			{ typeof(int?), "INTEGER" },
			{ typeof(DateTime?), "DATE" },
		};

		public string FormatValue(object? value)
		{
			switch (value)
			{
				case string:
					return $"'{value}'";
				case byte[]:
					string res = "";
					string file = BitConverter.ToString((byte[])value, 0);
					if (file == "")
						res += "0x0";
					else
						res += "0x" + file.Replace("-", "");
					return res;
				default:
					return value?.ToString();
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
