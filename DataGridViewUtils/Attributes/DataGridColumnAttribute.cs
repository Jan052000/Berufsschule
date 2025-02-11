namespace DataGridViewUtils.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class DataGridColumnAttribute : Attribute
	{
		public string DisplayName { get; set; }
		public bool Readonly { get; set; }
		public Type CellType { get; set; }
		public string? Format { get; }

		public DataGridColumnAttribute(string displayName, Type cellType, bool _readonly = false, string? format = null)
		{
			DisplayName = displayName;
			Readonly = _readonly;
			CellType = cellType;
			Format = format;
		}
	}
}
