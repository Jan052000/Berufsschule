using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liegeplatzverwaltung.DataGridViewUtils
{
	public class DataGridViewCellSwitch
	{
		private static Dictionary<Type, Func<DataGridViewCell>> CellTypeSwitch = new Dictionary<Type, Func<DataGridViewCell>>()
		{
			{typeof(DataGridViewTextBoxCell), () => new DataGridViewTextBoxCell()},
			{typeof(DataGridViewComboBoxCell), () => new DataGridViewComboBoxCell()},
		};

		public static DataGridViewCell SwitchType(Type type)
		{
			return CellTypeSwitch[type]();
		}
	}
}
