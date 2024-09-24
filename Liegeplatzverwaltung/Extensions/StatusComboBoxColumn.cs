using Liegeplatzverwaltung.DataBaseObjects;
using Liegeplatzverwaltung.DataGridViewUtils.Attributes;

namespace Liegeplatzverwaltung.Extensions
{
	public class StatusComboBoxColumn : DataGridColumnAttribute
	{
		public List<string> StatusNames
		{
			get
			{
				return Enum.GetNames(typeof(Status)).ToList();
			}
		}

		public StatusComboBoxColumn(string displayName, bool _readonly = false) : base(displayName, typeof(DataGridViewComboBoxCell), _readonly)
		{
		}
	}
}
