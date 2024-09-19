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
		private Dictionary<Type, string> TypeSwitch { get; } = new Dictionary<Type, string>()
		{
			{ typeof(string), "TEXT" },
			{ typeof(int), "INT" },
			{ typeof(DateTime), "DATE" },
			{ typeof(byte[]), "BLOB" },
			{ typeof(int?), "INT" },
			{ typeof(DateTime?), "DATE" },
		};

		public string GetDBType(Type type)
		{
			if (!TypeSwitch.ContainsKey(type))
				return "TEXT";
			return TypeSwitch[type];
		}
	}
}
