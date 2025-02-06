using DataBaseUtils;
using HumanBenchmarks.Db;
using HumanBenchmarks.Db.Classes;

namespace HumanBenchmarks.Forms
{
	internal partial class LoginForm : Form
	{
		public UserClass? User { get; set; }

		public LoginForm()
		{
			InitializeComponent();
			nudID.Maximum = decimal.MaxValue;
		}

		private void btRegister_Click(object sender, EventArgs e)
		{
			using var conn = DbConnection.GetSQLiteConnection();
			using (System.Data.Common.DbCommand cmd = conn.CreateCommand())
			{
				cmd.CommandText = DbUtils.GetGetCountCommand<UserClass>();
				long l = cmd.ExecuteScalar() as long? ?? 0;
				RegisterForm rf = new RegisterForm(l + 1);
				rf.ShowDialog();
				if (rf.DialogResult != DialogResult.OK)
					return;
				User = rf.NewUser;
			}
			using (System.Data.Common.DbCommand cmd = conn.CreateCommand())
			{
				cmd.CommandText = DbUtils.GetInsertCommand(User!, DbConnection.DbDialect);
				cmd.ExecuteNonQuery();
			}
			Close();
		}

		private void btLogin_Click(object sender, EventArgs e)
		{
			using var conn = DbConnection.GetSQLiteConnection();
			using (var cmd = conn.CreateCommand())
			{
				cmd.CommandText = DbUtils.GetGetSingleCommand(new UserClass() { Id = (int)nudID.Value }, DbConnection.DbDialect);
				using (var reader = cmd.ExecuteReader())
				{
					if (!reader.Read())
					{
						toolTip1.Show($"No user with id {nudID.Value} was found", this);
						return;
					}
					User = DbBaseClass.Serialize<UserClass>(reader);
				}
			}
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
