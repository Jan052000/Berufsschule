namespace Liegeplatzverwaltung.DataBaseUtils
{
	public interface IDbTypeSwitch
	{
		string GetDBType(Type type);
		string FormatValue(object? value);
	}
}
