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
