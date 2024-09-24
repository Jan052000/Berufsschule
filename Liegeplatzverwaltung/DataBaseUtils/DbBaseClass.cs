using Liegeplatzverwaltung.DataBaseUtils.Attributes;
using System.Data.Common;
using System.Reflection;
using System.Text;

namespace Liegeplatzverwaltung.DataBaseUtils
{
	public class DbBaseClass
	{
		/// <summary>
		/// Serializes an object of <see cref="Type"/> <typeparamref name="T"/> from a row in <paramref name="reader"/>
		/// </summary>
		/// <typeparam name="T"><see cref="Type"/> to serialize object of</typeparam>
		/// <param name="reader"><see cref="DbDataReader"/> that holds data to serialize</param>
		/// <returns>Objet of <see cref="Type"/> <typeparamref name="T"/> filled with informarion from <paramref name="reader"/></returns>
		public static T Serialize<T>(DbDataReader reader) where T : DbBaseClass, new()
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
						else if (property.PropertyType.IsEnum)
						{
							var temp = reader.GetValue(ord);
							if (temp is string s)
								property.SetValue(n, Enum.Parse(property.PropertyType, s));
							else
								throw new NotImplementedException();
						}
						else
							property.SetValue(n, reader.GetValue(ord));
					}
				}
			}

			return n;
		}

		/// <summary>
		/// Converts the string resulting from a call to <see cref="BitConverter.ToString(byte[])"/> back to a <see cref="byte"/>[]
		/// </summary>
		/// <param name="byteArray">String obtained from <see cref="BitConverter"/></param>
		/// <returns>1 to 1 <see cref="byte"/>[] translation of <paramref name="byteArray"/></returns>
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
