using Liegeplatzverwaltung.DataGridViewUtils.Attributes;
using Liegeplatzverwaltung.DataGridViewUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Liegeplatzverwaltung.DataBaseObjects;

namespace Liegeplatzverwaltung.Extensions
{
	public class DataGridViewUtils : Liegeplatzverwaltung.DataGridViewUtils.DataGridViewUtils
	{
		/// <inheritdoc cref="Liegeplatzverwaltung.DataGridViewUtils.DataGridViewUtils.AddItemToDataGridView{T}(DataGridView, T)"/>
		public static new void AddItemToDataGridView<T>(DataGridView dataGridView, T item) where T : class
		{
			Liegeplatzverwaltung.DataGridViewUtils.DataGridViewUtils.AddItemToDataGridView(dataGridView, item);
			if (item is not Liegeplatz liegeplatz)
				return;
			PropertyInfo status = liegeplatz.GetType().GetProperty("Status")!;
			StatusComboBoxColumn colAttr = status.GetCustomAttribute<StatusComboBoxColumn>()!;

			foreach (DataGridViewRow row in dataGridView.Rows)
			{
				DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)row.Cells[GetColumnName(colAttr.DisplayName)];
				cell.Items.Clear();
				colAttr.StatusNames.ForEach(name => cell.Items.Add(name));
				cell.Value = Enum.GetName(typeof(Status), ((Liegeplatz)row.Tag!).Status);
			}
		}
	}
}
