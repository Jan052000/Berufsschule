using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liegeplatzverwaltung.DataBaseUtils.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class PrimaryKeyAttribute : ColumnAttribute
	{
		public bool AutoIncrement { get; set; } = false;
		public bool AllowNull { get; set; } = false;
		public PrimaryKeyAttribute(string columnName) : base(columnName)
		{

		}
	}
}
