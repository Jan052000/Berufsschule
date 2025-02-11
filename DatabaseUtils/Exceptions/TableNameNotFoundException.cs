namespace DatabaseUtils.Exceptions
{
	public class TableNameNotFoundException : Exception
	{
		public TableNameNotFoundException(string typeName) : base($"No table name was defined for type {typeName}")
		{

		}

		public TableNameNotFoundException(Type type) : base($"No table name was defined for type {type.Name}")
		{

		}
	}
}
