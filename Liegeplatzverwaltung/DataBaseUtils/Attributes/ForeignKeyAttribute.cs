namespace Liegeplatzverwaltung.DataBaseUtils.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class ForeignKeyAttribute : ColumnAttribute
	{
		public string ReferencedTable { get; }
		public string ReferencedColumn { get; }
		public ForeignKeyAttribute(string columnName, string referencedTable, string referencedColumn) : base(columnName)
		{
			ReferencedTable = referencedTable;
			ReferencedColumn = referencedColumn;
		}

		public ForeignKeyAttribute(string columnName, Type tableType, string referencedColumn) : base(columnName)
		{
			ReferencedColumn = referencedColumn;
			ReferencedTable = DbUtils.GetTableName(tableType);
		}
	}
}
