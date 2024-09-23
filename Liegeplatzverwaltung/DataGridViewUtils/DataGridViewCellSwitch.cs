namespace Liegeplatzverwaltung.DataGridViewUtils
{
	public class DataGridViewCellSwitch
	{
		private static Dictionary<Type, Func<DataGridViewColumn>> CellTypeSwitch = new Dictionary<Type, Func<DataGridViewColumn>>()
		{
			{typeof(DataGridViewTextBoxCell), () => new DataGridViewTextBoxColumn()},
			{typeof(DataGridViewComboBoxCell), () => new DataGridViewComboBoxColumn()},
			{typeof(DataGridViewImageCell), () => new DataGridViewImageColumn()}
		};

		public static DataGridViewColumn SwitchType(Type type)
		{
			return CellTypeSwitch[type]();
		}
	}
}
