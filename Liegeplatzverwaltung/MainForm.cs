using Liegeplatzverwaltung.DataBaseObjects;
using Liegeplatzverwaltung.DataBaseUtils;
using System.Data.SQLite;
using System.Reflection;

namespace Liegeplatzverwaltung
{
	public partial class MainForm : Form
	{
		private const string DBFILENAME = "liegeplaetze.db";
		private static string DbPath = Path.GetFullPath($"./{DBFILENAME}");
		private static string ConnectionString = $"Data Source={DbPath}; Version=3";

		private bool IsUpdating { get; set; } = false;

		public MainForm()
		{
			SetUpDataBase();
			InitializeComponent();
			DataGridViewUtils.DataGridViewUtils.GenerateColumns(dataGridView1, new Liegeplatz());
			FillDataGridView();
			dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
		}

		private void FillDataGridView()
		{
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
			DataGridView? dgv = sender as DataGridView;
			if (dgv is null)
				return;
			DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
			if (MessageBox.Show("Save changes?", "Save changes?", MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				IsUpdating = true;
				cell.Value = DataGridViewUtils.DataGridViewUtils.GetTagValueForCell(cell);
				IsUpdating = false;
				return;
			}
			using SQLiteConnection conn = new SQLiteConnection(ConnectionString);
			conn.Open();
			using SQLiteCommand cmd = conn.CreateCommand();

			DataGridViewUtils.DataGridViewUtils.UpdateInfoOnTag(cell, (Liegeplatz)cell.OwningRow.Tag!);

			cmd.CommandText = DbUtils.GetUpdateRowCommand((Liegeplatz)dgv.Rows[e.RowIndex].Tag!, new SQLiteDialect());
			cmd.ExecuteNonQuery();
		}

		private void btRemoveSelected_Click(object sender, EventArgs e)
		{
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
	}
}
