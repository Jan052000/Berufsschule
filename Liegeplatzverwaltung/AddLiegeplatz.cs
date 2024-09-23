using Liegeplatzverwaltung.DataBaseObjects;
using Liegeplatzverwaltung.DataBaseUtils.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Liegeplatzverwaltung
{
	public partial class AddLiegeplatz : Form
	{
		public Liegeplatz? Result { get; private set; }

		public AddLiegeplatz()
		{
			InitializeComponent();
			SetupflpControls();
		}

		private void SetupflpControls()
		{
			List<Label> labels = new List<Label>();
			List<TextBox> textBoxes = new List<TextBox>();
			List<Panel> panels = new List<Panel>();
			foreach (var property in typeof(Liegeplatz).GetProperties().Where(prop => prop.GetCustomAttribute<ColumnAttribute>() is not null))
			{
				if (property.GetCustomAttribute<PrimaryKeyAttribute>() is PrimaryKeyAttribute primaryKeyAttribute && primaryKeyAttribute.AutoIncrement)
					continue;
				Panel pa = new Panel();
				panels.Add(pa);

				Label l = new Label()
				{
					Text = property.GetCustomAttribute<ColumnAttribute>()!.ColumnName
				};
				l.Size = TextRenderer.MeasureText(l.Text, l.Font);
				pa.Controls.Add(l);
				labels.Add(l);

				TextBox tb = new TextBox();
				if (property.PropertyType == typeof(byte[]))
				{
					tb.ReadOnly = true;
					tb.Enter += (s, e) =>
					{
						OpenFileDialog fd = new OpenFileDialog()
						{
							Filter = "Files|*.jpg;*.jpeg;*.png;"
						};
						if (fd.ShowDialog() != DialogResult.OK)
							return;
						((TextBox)s!).Text = fd.FileName;
					};
				}
				pa.Controls.Add(tb);
				textBoxes.Add(tb);

				pa.Height = tb.Bounds.Height + tb.Margin.Top + tb.Margin.Bottom;
				pa.Dock = DockStyle.Top;
				pa.Tag = property;
				paControls.Controls.Add(pa);
			}

			int tbStartPos = labels.Select(label => label.Bounds.Y + label.Bounds.Width + label.Margin.Right).Max();
			textBoxes.ForEach(tb =>
			{
				tb.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
				tb.Location = new Point(tbStartPos, tb.Parent!.Height / 2 - tb.Height / 2);
				tb.Width = tb.Parent!.Width - tb.Location.X - tb.Parent.Margin.Right;
			});
			labels.ForEach(la => la.Location = new Point(la.Location.X, textBoxes.First().Height / 2 - la.Height / 2));
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void btAdd_Click(object sender, EventArgs e)
		{
			Result = new Liegeplatz();

			foreach (Control control in paControls.Controls)
			{
				if (control is not Panel panel || panel.Tag is not PropertyInfo propertyInfo)
					continue;
				foreach (Control childControl in panel.Controls)
				{
					if (childControl is not TextBox textBox)
						continue;
					if (Nullable.GetUnderlyingType(propertyInfo.PropertyType) != null)
						propertyInfo.SetValue(Result, textBox.Text != "" ? SwitchNullable(textBox.Text, propertyInfo.PropertyType) : null);
					else
					{
						if (propertyInfo.PropertyType == typeof(byte[]))
						{
							Image img = Image.FromFile(textBox.Text);
							using MemoryStream ms = new MemoryStream();
							img.Save(ms, img.RawFormat);

							propertyInfo.SetValue(Result, textBox.Text != "" ? ImageCompression.Compress(ms.ToArray()) : SwitchDefault(propertyInfo.PropertyType));
						}
						else
							propertyInfo.SetValue(Result, textBox.Text != "" ? textBox.Text : SwitchDefault(propertyInfo.PropertyType));
					}
				}
			}

			DialogResult = DialogResult.OK;

			object? SwitchDefault(Type type)
			{
				if (type == typeof(long) || type == typeof(int) || type == typeof(double) || type == typeof(decimal))
					return -1;
				if (type == typeof(string))
					return "";
				if (type == typeof(DateTime))
					return new DateTime();
				if (type == typeof(byte[]))
					return new byte[0];
				return null;
			}

			object? SwitchNullable(string input, Type type)
			{
				if (type == typeof(long?))
					return Extensions.ToNullable<long>(input);
				if (type == typeof(int?))
					return Extensions.ToNullable<int>(input);
				if (type == typeof(DateTime?))
					return Extensions.ToNullable<DateTime>(input);
				throw new NotImplementedException();
			}
		}
	}
}
