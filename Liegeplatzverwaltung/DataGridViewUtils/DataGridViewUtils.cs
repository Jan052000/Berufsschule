using Liegeplatzverwaltung.DataBaseObjects;
using Liegeplatzverwaltung.DataGridViewUtils.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Liegeplatzverwaltung.DataGridViewUtils
{
	public class DataGridViewUtils
	{
		public static string GetColumnName(string propertyName)
		{
			return $"col{propertyName}";
		}

		public static void GenerateColumns<T>(DataGridView dataGridView, T obj) where T : class
		{
			List<PropertyInfo> columns = obj.GetType().GetProperties().Where(prop => prop.GetCustomAttribute<DataGridColumnAttribute>() != null).ToList();
			dataGridView.Columns.Clear();

			foreach (PropertyInfo property in columns)
			{
				DataGridColumnAttribute column = property.GetCustomAttribute<DataGridColumnAttribute>()!;
				DataGridViewColumn col = DataGridViewCellSwitch.SwitchType(column.CellType);
				col.Name = "col" + column.DisplayName;
				col.HeaderText = column.DisplayName;
				int index = dataGridView.Columns.Add(col);
				if (column.Readonly)
					dataGridView.Columns[index].ReadOnly = true;
			}
		}

		public static void AddItemToDataGridView<T>(DataGridView dataGridView, T item) where T : class
		{
			if (dataGridView.Columns.Count == 0)
				return;
			DataGridViewRow row = new DataGridViewRow();
			int index = dataGridView.Rows.Add(row);
			item.GetType().GetProperties().ToList().ForEach(prop =>
			{
				if (prop.GetCustomAttribute<DataGridColumnAttribute>() is not DataGridColumnAttribute attr)
					return;
				if (attr.CellType == typeof(DataGridViewImageCell))
				{
					using MemoryStream ms = new MemoryStream(ImageCompression.Decompress((byte[])prop.GetValue(item)));
					dataGridView.Rows[index].Cells[GetColumnName(attr.DisplayName)].Value = ms.Length > 0 ? Image.FromStream(ms) : null;
				}
				else
					dataGridView.Rows[index].Cells[GetColumnName(attr.DisplayName)].Value = prop.GetValue(item);
				//dataGridView.Rows[index].Cells[GetColumnName(attr.DisplayName)].Tag = prop;
				dataGridView.Rows[index].Tag = item;
			});
		}

		public static void UpdateInfoOnTag(DataGridViewCell cell, Liegeplatz pier)
		{
			List<PropertyInfo> toUpdate = pier.GetType().GetProperties().Where(prop => prop.GetCustomAttribute<DataGridColumnAttribute>() is DataGridColumnAttribute attr && attr.DisplayName == cell.OwningColumn.HeaderText).ToList();
			foreach (PropertyInfo property in toUpdate)
			{
				property.SetValue(pier, cell.Value);
			}
		}

		public static object? GetTagValueForCell(DataGridViewCell cell)
		{
			Liegeplatz? pier = cell.OwningRow.Tag as Liegeplatz;
			PropertyInfo? pi = pier?.GetType().GetProperties().FirstOrDefault(prop => prop.GetCustomAttribute<DataGridColumnAttribute>() is DataGridColumnAttribute attr && attr.DisplayName == cell.OwningColumn.HeaderText);
			if (pi == null)
				throw new NullReferenceException();
			return pi.GetValue(pier);
		}
	}
}
