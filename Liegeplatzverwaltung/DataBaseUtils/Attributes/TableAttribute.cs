namespace Liegeplatzverwaltung.DataBaseUtils.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class TableAttribute : Attribute
	{
		public string TableName { get; }
		public TableAttribute(string tableName)
		{
			TableName = tableName;
		}
	}
}
