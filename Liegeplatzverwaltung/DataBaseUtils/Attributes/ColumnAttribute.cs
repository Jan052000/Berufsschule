using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liegeplatzverwaltung.DataBaseUtils.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class ColumnAttribute : Attribute
	{
		public string ColumnName { get; }
		public ColumnAttribute(string columnName)
		{
			ColumnName = columnName;
		}
	}
}
