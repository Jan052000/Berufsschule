using System.ComponentModel;

namespace Liegeplatzverwaltung
{
	public static class Extensions
	{
		/// <summary>
		/// Wraps <typeparamref name="T"/> inside of <see cref="Nullable"/>
		/// </summary>
		/// <typeparam name="T">Base <see cref="Type"/> to wrap</typeparam>
		/// <param name="value"><see cref="string"/> value to convert to a <see cref="Nullable{T}"/></param>
		/// <returns>New <see cref="Nullable{T}"/></returns>
		public static Nullable<T> ToNullable<T>(this string value) where T : struct
		{
			Nullable<T> result = new Nullable<T>();
			try
			{
				if (!string.IsNullOrEmpty(value) && value.Trim().Length > 0)
				{
					TypeConverter conv = TypeDescriptor.GetConverter(typeof(T));
					result = (T)conv.ConvertFrom(value);
				}
			}
			catch { }
			return result;
		}
	}
}
