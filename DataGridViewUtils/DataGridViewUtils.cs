using DataGridViewUtils.Attributes;
using System.Reflection;

namespace DataGridViewUtils
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
		public static void GenerateColumns<T>(DataGridView dataGridView, T? obj = null) where T : class
		{
			if (obj == null)
				GenerateColumns(dataGridView, typeof(T));
			else
				GenerateColumns(dataGridView, obj.GetType());
		}

		/// <summary>
		/// Generates named columns from <see cref="DataGridColumnAttribute"/>s of <paramref name="contentType"/>
		/// </summary>
		/// <param name="dataGridView"><see cref="DataGridView"/> to generate columns in</param>
		/// <param name="contentType"><see cref="Type"/> to grab property attributes from</param>
		public static void GenerateColumns(DataGridView dataGridView, Type contentType)
		{
			List<PropertyInfo> columns = contentType.GetProperties().Where(prop => prop.GetCustomAttribute<DataGridColumnAttribute>() != null).ToList();
			dataGridView.Columns.Clear();

			foreach (PropertyInfo property in columns)
			{
				DataGridColumnAttribute column = property.GetCustomAttribute<DataGridColumnAttribute>()!;
				DataGridViewColumn col = DataGridViewCellSwitch.SwitchType(column.CellType);
				if (column.Format is string format)
					col.DefaultCellStyle.Format = format;
				col.Name = "col" + column.DisplayName;
				col.HeaderText = column.DisplayName;
				int index = dataGridView.Columns.Add(col);
				if (column.Readonly)
					dataGridView.Columns[index].ReadOnly = true;
				col.Tag = property;
			}
		}

		/// <summary>
		/// Adds an <paramref name="item"/> to the <paramref name="dataGridView"/>
		/// </summary>
		/// <typeparam name="T"><see cref="Type"/> of item to add using property attributes</typeparam>
		/// <param name="dataGridView"><see cref="DataGridView"/> to fill with data</param>
		/// <param name="item">Item of <see cref="Type"/> <typeparamref name="T"/> to add to <paramref name="dataGridView"/></param>
		/// <param name="selectedBackColor"><see cref="Color"/> selected cells should have as background</param>
		/// <param name="selectedForeColor"><see cref="Color"/> selected cells should have as text color</param>
		public static void AddItemToDataGridView<T>(DataGridView dataGridView, T item, Color? selectedBackColor = null, Color? selectedForeColor = null) where T : class
		{
			if (dataGridView.Columns.Count == 0)
				return;
			DataGridViewRow row = new DataGridViewRow();
			if (selectedBackColor is Color back && selectedForeColor is Color fore)
			{
				row.DefaultCellStyle.SelectionBackColor = back;
				row.DefaultCellStyle.SelectionForeColor = fore;
			}
			int index = dataGridView.Rows.Add(row);
			item.GetType().GetProperties().ToList().ForEach(prop =>
			{
				if (prop.GetCustomAttribute<DataGridColumnAttribute>() is not DataGridColumnAttribute attr)
					return;
				if (attr.CellType == typeof(DataGridViewImageCell))
				{
					using MemoryStream ms = new MemoryStream(prop.GetValue(item) as byte[] ?? Array.Empty<byte>());
					dataGridView.Rows[index].Cells[GetColumnName(attr.DisplayName)].Value = ms.Length > 0 ? Image.FromStream(ms) : null;
				}
				else if (attr.CellType == typeof(DataGridViewComboBoxCell))
				{
					if (prop.GetValue(item) is null)
						throw new NotImplementedException("Null as combo box option");
					if (!prop.PropertyType.IsEnum)
						throw new NotImplementedException("Combo box cell that does not have an enum as data source");
					DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)row.Cells[GetColumnName(attr.DisplayName)];
					cell.Items.Clear();
					Enum.GetNames(prop.PropertyType).ToList().ForEach(name => cell.Items.Add(name));
					cell.Value = Enum.GetName(prop.PropertyType, prop.GetValue(item)!);
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
		/// <param name="obj">Object to update cell value with</param>
		public static void UpdateInfoOnTag<T>(DataGridViewCell cell, T obj)
		{
			if (obj is null)
				throw new ArgumentNullException(nameof(obj));
			List<PropertyInfo> toUpdate = obj.GetType().GetProperties().Where(prop => prop.GetCustomAttribute<DataGridColumnAttribute>() is DataGridColumnAttribute attr && attr.DisplayName == cell.OwningColumn.HeaderText).ToList();
			foreach (PropertyInfo property in toUpdate)
			{
				if (property.PropertyType.IsEnum)
				{
					if (cell.Value is string str)
						property.SetValue(obj, Enum.Parse(property.PropertyType, str));
					else
						throw new NotImplementedException();
				}
				else
					property.SetValue(obj, cell.Value);
			}
		}

		/// <summary>
		/// Gets the value for a cell from the Tag of its <see cref="DataGridViewColumn"/>
		/// </summary>
		/// <param name="cell"><see cref="DataGridViewCell"/> to get value for</param>
		/// <typeparam name="T"><see cref="Type"/> of <paramref name="cell"/> tag</typeparam>
		/// <returns>Value that cell should have according to Tag</returns>
		/// <exception cref="NullReferenceException"></exception>
		public static object? GetTagValueForCell<T>(DataGridViewCell cell) where T : class
		{
			T? pier = cell.OwningRow.Tag as T;
			PropertyInfo? pi = pier?.GetType().GetProperties().FirstOrDefault(prop => prop.GetCustomAttribute<DataGridColumnAttribute>() is DataGridColumnAttribute attr && attr.DisplayName == cell.OwningColumn.HeaderText);
			if (pi == null)
				throw new NullReferenceException();
			return pi.GetValue(pier);
		}
	}
}
