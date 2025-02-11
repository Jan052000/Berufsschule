namespace DataGridViewUtils
{
	public class DataGridViewCellSwitch
	{
		private static Dictionary<Type, Func<DataGridViewColumn>> CellTypeSwitch = new Dictionary<Type, Func<DataGridViewColumn>>()
		{
			{typeof(DataGridViewTextBoxCell), () => new DataGridViewTextBoxColumn()},
			{typeof(DataGridViewComboBoxCell), () => new DataGridViewComboBoxColumn()},
			{typeof(DataGridViewImageCell), () => new DataGridViewImageColumn()}
		};

		/// <summary>
		/// Switches the <paramref name="type"/> of <see cref="DataGridViewColumn"/>s to match input
		/// </summary>
		/// <param name="type"><see cref="Type"/> of <see cref="DataGridViewCell"/> to get column of</param>
		/// <returns><see cref="DataGridViewColumn"/> that matches <paramref name="type"/></returns>
		public static DataGridViewColumn SwitchType(Type type)
		{
			return CellTypeSwitch[type]();
		}
	}
}
