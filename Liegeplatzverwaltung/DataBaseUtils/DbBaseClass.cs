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
					if (reader.IsDBNull(ord))
						property.SetValue(n, null);
					else
					{
						if (property.PropertyType == typeof(byte[]))
						{
							var blobValue = (byte[])reader.GetValue(ord);
							var byteArrayString = Encoding.UTF8.GetString(blobValue);
							var byteArray = ByteStringToArray(byteArrayString);
							property.SetValue(n, byteArray);
						}
						else
							property.SetValue(n, reader.GetValue(ord));
					}
				}
			}

			return n;
		}

		private static byte[] ByteStringToArray(string byteArray)
		{
			int length = (byteArray.Length + 1) / 3;
			byte[] result = new byte[length];
			for (int i = 0; i < length; i++)
				result[i] = Convert.ToByte(byteArray.Substring(3 * i, 2), 16);
			return result;
		}
	}
}
