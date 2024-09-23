namespace Liegeplatzverwaltung.DataBaseUtils
{
	public interface IDbTypeSwitch
	{
		string AutoIncrementString { get; }
		string InLinePrimaryKeyString { get; }
		string GetDBType(Type type);
		string FormatValue(object? value, Type valueType);
	}
}
