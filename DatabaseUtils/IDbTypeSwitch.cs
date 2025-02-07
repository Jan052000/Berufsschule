namespace DataBaseUtils
{
	public interface IDbTypeSwitch
	{
		/// <summary>
		/// String to indicate inline auto increment
		/// </summary>
		string AutoIncrementString { get; }
		/// <summary>
		/// String to indicate inline primary key
		/// </summary>
		string InLinePrimaryKeyString { get; }
		/// <summary>
		/// String to add to column when it is required to have a value
		/// </summary>
		string RequiredString { get; }
		/// <summary>
		/// Format for <see cref="DateTime"/> strings in database
		/// </summary>
		string DateFormat { get; }
		/// <summary>
		/// Gets the string representation for dialect specific DBTypes
		/// </summary>
		/// <param name="type"><see cref="Type"/> of c# property to transform</param>
		/// <returns>String representation for dialect specific DBTypes</returns>
		string GetDBType(Type type);
		/// <summary>
		/// Formats a <paramref name="value"/> into a data base command value
		/// </summary>
		/// <param name="value">Value to transform</param>
		/// <returns>String representation of <paramref name="value"/> in a command</returns>
		string FormatValue(object? value);
	}
}
