using Liegeplatzverwaltung.DataBaseObjects;
using Liegeplatzverwaltung.DataBaseUtils;
using System.Data.SQLite;

namespace Liegeplatzverwaltung
{
	public partial class MainForm : Form
	{
		private const string DBFILENAME = "liegeplaetze.db";
		private static string DbPath = Path.GetFullPath($"./{DBFILENAME}");
		private static string ConnectionString = $"Data Source={DbPath}; Version=3";
		public MainForm()
		{
			SetUpDataBase();
			InitializeComponent();
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
				cmd.CommandText = DbUtils.GetFillTableWithDataCommand(TestData.GetBesitzerData());
				cmd.ExecuteNonQuery();
			}

			using (SQLiteCommand cmd = conn.CreateCommand())
			{
				cmd.CommandText = DbUtils.GetCreateCommand<Yacht>(new SQLiteDialect());
				cmd.ExecuteNonQuery();
			}
			using (SQLiteCommand cmd = conn.CreateCommand())
			{
				cmd.CommandText = DbUtils.GetFillTableWithDataCommand(TestData.GetYachtData());
				cmd.ExecuteNonQuery();
			}

			using (SQLiteCommand com = conn.CreateCommand())
			{
				com.CommandText = DbUtils.GetCreateCommand<Liegeplatz>(new SQLiteDialect());
				com.ExecuteNonQuery();
			}
			using (SQLiteCommand cmd = conn.CreateCommand())
			{
				cmd.CommandText = DbUtils.GetFillTableWithDataCommand(TestData.GetLiegeplatzData());
				cmd.ExecuteNonQuery();
			}
		}
	}
}
