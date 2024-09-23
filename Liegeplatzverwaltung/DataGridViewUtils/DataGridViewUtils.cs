using Liegeplatzverwaltung.DataBaseObjects;
using Liegeplatzverwaltung.DataGridViewUtils.Attributes;
using System.Reflection;

namespace Liegeplatzverwaltung.DataGridViewUtils
{
	public class DataGridViewUtils
	{
		/// <summary>
		/// Generates a name with the col prefix
		/// </summary>
		/// <param name="propertyName">Name of the property</param>
		/// <returns>Column name with col prefix</returns>
		public static string GetColumnName(string propertyName)
		{
			return $"col{propertyName}";
		}

		/// <summary>
		/// Generates the named columns for <paramref name="obj"/>
		/// </summary>
		/// <typeparam name="T"><see cref="Type"/> to grab propertiy attributes from</typeparam>
		/// <param name="dataGridView"><see cref="DataGridView"/> to generate columns in</param>
		/// <param name="obj"><typeparamref name="T"/> to grab property attributes from</param>
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

		/// <summary>
		/// Adds an <paramref name="item"/> to the <paramref name="dataGridView"/>
		/// </summary>
		/// <typeparam name="T"><see cref="Type"/> of item to add using property attributes</typeparam>
		/// <param name="dataGridView"><see cref="DataGridView"/> to fill with data</param>
		/// <param name="item">Item of <see cref="Type"/> <typeparamref name="T"/> to add to <paramref name="dataGridView"/></param>
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
				dataGridView.Rows[index].Tag = item;
			});
		}

		/// <summary>
		/// Updates data from <paramref name="pier"/> to match that of <paramref name="cell"/>
		/// </summary>
		/// <param name="cell"><see cref="DataGridViewCell"/> to grab value from</param>
		/// <param name="pier"><see cref="Liegeplatz"/> to update</param>
		public static void UpdateInfoOnTag(DataGridViewCell cell, Liegeplatz pier)
		{
			List<PropertyInfo> toUpdate = pier.GetType().GetProperties().Where(prop => prop.GetCustomAttribute<DataGridColumnAttribute>() is DataGridColumnAttribute attr && attr.DisplayName == cell.OwningColumn.HeaderText).ToList();
			foreach (PropertyInfo property in toUpdate)
			{
				property.SetValue(pier, cell.Value);
			}
		}

		/// <summary>
		/// Gets the value for a cell from the Tag of its <see cref="DataGridViewColumn"/>
		/// </summary>
		/// <param name="cell"><see cref="DataGridViewCell"/> to get value for</param>
		/// <returns>Value that cell should have according to Tag</returns>
		/// <exception cref="NullReferenceException"></exception>
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
