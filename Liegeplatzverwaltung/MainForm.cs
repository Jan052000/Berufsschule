using Liegeplatzverwaltung.DataBaseObjects;
using Liegeplatzverwaltung.DataBaseUtils;
using Liegeplatzverwaltung.Extensions;
using Liegeplatzverwaltung.FrontendConnection;
using Liegeplatzverwaltung.RequestBooking;
using System.Data.SQLite;
using System.Net;

namespace Liegeplatzverwaltung
{
	public partial class MainForm : Form
	{
		private const string DBFILENAME = "liegeplaetze.db";
		private static string DbPath = Path.GetFullPath($"./{DBFILENAME}");
		internal static string ConnectionString = $"Data Source={DbPath}; Version=3";

		private Dictionary<ResponseObject, HttpListenerResponse> Requests = new Dictionary<ResponseObject, HttpListenerResponse>();

		private bool IsUpdating { get; set; } = false;

		public MainForm()
		{
			SetUpDataBase();
			InitializeComponent();
			this.SetIcon();
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			DataGridViewUtils.DataGridViewUtils.GenerateColumns(dataGridView1, new Liegeplatz());
			FillDataGridView();
			this.SetTheme();
			new ListenerClass((respObj, resp) =>
			{
				if (btRequests.InvokeRequired)
					btRequests.BeginInvoke(new MethodInvoker(Increment));
				else
					Increment();
				Requests.Add(respObj, resp);

				void Increment()
				{
					btRequests.MessageCount++;
				}
			}).Start();
		}

		private void FillDataGridView()
		{
			dataGridView1.CellValueChanged -= dataGridView1_CellValueChanged;
			dataGridView1.Rows.Clear();
			using SQLiteConnection conn = new SQLiteConnection(ConnectionString);
			conn.Open();
			using (SQLiteCommand cmd = conn.CreateCommand())
			{
				cmd.CommandText = DbUtils.GetGetAllCommand<Liegeplatz>();
				SQLiteDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					DataGridViewUtils.DataGridViewUtils.AddItemToDataGridView(dataGridView1, DbBaseClass.Serialize<Liegeplatz>(reader));
				}
			}
			dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
		}

		private void SetUpDataBase()
		{
			if (File.Exists(DbPath))
				return;
			using SQLiteConnection conn = new SQLiteConnection(ConnectionString);
			conn.Open();
			using (SQLiteCommand cmd = conn.CreateCommand())
			{
				cmd.CommandText = DbUtils.GetCreateCommand<Besitzer>(new SQLiteDialect());
				cmd.ExecuteNonQuery();
			}
			using (SQLiteCommand cmd = conn.CreateCommand())
			{
				cmd.CommandText = DbUtils.GetFillTableWithDataCommand(TestData.GetBesitzerData(), new SQLiteDialect());
				cmd.ExecuteNonQuery();
			}

			using (SQLiteCommand cmd = conn.CreateCommand())
			{
				cmd.CommandText = DbUtils.GetCreateCommand<Yacht>(new SQLiteDialect());
				cmd.ExecuteNonQuery();
			}
			using (SQLiteCommand cmd = conn.CreateCommand())
			{
				cmd.CommandText = DbUtils.GetFillTableWithDataCommand(TestData.GetYachtData(), new SQLiteDialect());
				cmd.ExecuteNonQuery();
			}

			using (SQLiteCommand com = conn.CreateCommand())
			{
				com.CommandText = DbUtils.GetCreateCommand<Liegeplatz>(new SQLiteDialect());
				com.ExecuteNonQuery();
			}
			using (SQLiteCommand cmd = conn.CreateCommand())
			{
				cmd.CommandText = DbUtils.GetFillTableWithDataCommand(TestData.GetLiegeplatzData(), new SQLiteDialect());
				cmd.ExecuteNonQuery();
			}
		}

		private void dataGridView1_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
		{
			if (IsUpdating)
				return;
			if (sender is not DataGridView dgv)
				return;
			DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
			if (MessageBox.Show("Save changes?", "Save changes?", MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				IsUpdating = true;
				cell.Value = DataGridViewUtils.DataGridViewUtils.GetTagValueForCell(cell);
				IsUpdating = false;
				return;
			}

			Liegeplatz tag = (Liegeplatz)dgv.Rows[e.RowIndex].Tag!;
			System.Reflection.PropertyInfo toChange = (System.Reflection.PropertyInfo)dataGridView1.Columns[e.ColumnIndex].Tag!;
			if (toChange.PropertyType.IsEnum)
				toChange.SetValue(tag, Enum.Parse(toChange.PropertyType, cell.Value.ToString()!));
			else
				toChange.SetValue(tag, Convert.ChangeType(cell.Value, toChange.PropertyType));

			using SQLiteConnection conn = new SQLiteConnection(ConnectionString);
			conn.Open();
			using SQLiteCommand cmd = conn.CreateCommand();

			cmd.CommandText = DbUtils.GetUpdateRowCommand((Liegeplatz)dgv.Rows[e.RowIndex].Tag!, new SQLiteDialect());
			cmd.ExecuteNonQuery();

			FillDataGridView();
		}

		private void btRemoveSelected_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count == 0)
				return;
			if (MessageBox.Show($"Delete {dataGridView1.SelectedRows.Count} rows?", "Delete seleted rows?", MessageBoxButtons.YesNo) != DialogResult.Yes)
				return;

			List<DataGridViewRow> toRemove = [.. dataGridView1.SelectedRows.Cast<DataGridViewRow>()];

			using SQLiteConnection conn = new SQLiteConnection(ConnectionString);
			conn.Open();
			using (SQLiteCommand cmd = conn.CreateCommand())
			{
				cmd.CommandText = DbUtils.GetDeleteCommand(toRemove.Select(item => item.Tag).Cast<Liegeplatz>().ToList(), new SQLiteDialect());
				cmd.ExecuteNonQuery();
			}

			toRemove.ForEach(dataGridView1.Rows.Remove);
		}

		private void btAddNew_Click(object sender, EventArgs e)
		{
			AddLiegeplatz form = new AddLiegeplatz();
			if (form.ShowDialog() != DialogResult.OK || form.Result is null)
				return;
			using SQLiteConnection conn = new SQLiteConnection(ConnectionString);
			conn.Open();
			using (SQLiteCommand cmd = conn.CreateCommand())
			{
				cmd.CommandText = DbUtils.GetFillTableWithDataCommand(new List<Liegeplatz> { form.Result }, new SQLiteDialect());
				cmd.ExecuteNonQuery();
			}
			dataGridView1.CellValueChanged -= dataGridView1_CellValueChanged;
			DataGridViewUtils.DataGridViewUtils.AddItemToDataGridView(dataGridView1, form.Result);
			dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
		}

		private void btRequests_Click(object sender, EventArgs e)
		{
			if (Requests.Count == 0)
			{
				MessageBox.Show("Keine neuen Anfragen verfügbar", "Im Listener nichts neues");
				return;
			}
			BookingRequests requests = new BookingRequests(Requests);
			requests.LiegeplatzAssigned += (respObj) =>
			{
				Requests.Remove(respObj);
				FillDataGridView();
				btRequests.MessageCount--;
			};
			requests.ShowDialog();
		}
	}
}
