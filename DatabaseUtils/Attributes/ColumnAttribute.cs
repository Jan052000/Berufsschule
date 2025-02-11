namespace DataBaseUtils.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class ColumnAttribute : Attribute
	{
		public string ColumnName { get; }

		public bool Required { get; }
		public ColumnAttribute(string columnName, bool required = false)
		{
			ColumnName = columnName;
			Required = required;
		}
	}
}
