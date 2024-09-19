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
	public class DbBaseClass
	{
		public static DbBaseClass Serialize<T>(DbDataReader reader) where T : DbBaseClass, new()
		{
			T n = new();
			List<PropertyInfo> properties = n.GetType().GetProperties().
				Where(prop => prop.GetCustomAttribute<ColumnAttribute>() != null).ToList();

			foreach (PropertyInfo property in properties)
			{
				int ord = reader.GetOrdinal(property.GetCustomAttribute<ColumnAttribute>()!.ColumnName);
				if (ord > -1)
				{
					property.SetValue(n, reader.GetValue(ord));
				}
			}

			return n;
		}
	}
}
