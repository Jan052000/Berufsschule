using DataBaseUtils;
using HumanBenchmarks.Db;
using HumanBenchmarks.Db.Classes;

namespace HumanBenchmarks.Forms
{
	internal partial class MainForm : Form
	{
		public UserClass? CurrentUser { get; set; }

		public MainForm()
		{
			DbConnection.InitDB();
			LoginForm login = new LoginForm();
			login.ShowDialog();
			CurrentUser = login.User;

			InitializeComponent();
			MinimumSize = new Size(GetMinimumWidth(), GetMinimumHeight());
		}

		private int GetMinimumWidth()
		{
			int btadmin = 2 * btAimTest.Location.X + btAimTest.Width + btAimTest.Margin.Left + btAimTest.Margin.Right;
			int btdashboard = btDashboard.Width + btDashboard.Margin.Left + btDashboard.Margin.Right;
			return btadmin + btdashboard + 6;
		}

		private int GetMinimumHeight()
		{
			return 200;
		}

		private void btClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btReactionCheck_Click(object sender, EventArgs e)
		{
			ReactionTest test = new ReactionTest();
			test.ShowDialog();
		}

		private void btSimonSays_Click(object sender, EventArgs e)
		{
			SimonSaysGame test = new SimonSaysGame();
			test.ShowDialog();
		}

		private void btAimTest_Click(object sender, EventArgs e)
		{
			AimTest test = new AimTest();
			test.ShowDialog();
		}

		private void btDashboard_Click(object sender, EventArgs e)
		{
			new Dashboard("").Show();
		}
	}
}
