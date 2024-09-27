using Liegeplatzverwaltung.Properties;

namespace Liegeplatzverwaltung.Extensions
{
	public static class FormExtension
	{
		public static void SetIcon(this Form form)
		{
			if (form is not Form nonNull)
				return;
			nonNull.Icon = Resources.habilidad;
		}
	}
}
