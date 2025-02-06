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
			if (CurrentUser == null)
				return;
			DateTime now = DateTime.Today;
			foreach (int score in test.Results)
			{
				DbConnection.SaveScore(
				new ScoreClass()
				{
					GameID = ReactionTest.GAMEID,
					ResidentID = CurrentUser.Id,
					TestDate = now,
					Score = score
				});
			}
		}

		private void btSimonSays_Click(object sender, EventArgs e)
		{
			SimonSaysGame test = new SimonSaysGame();
			test.ShowDialog();
			if (CurrentUser == null)
				return;
			DateTime now = DateTime.Today;
			foreach ((int Round, int Step) in test.Results)
			{
				int corrects = 0;
				for (int i = 1; i < Round; i++)
					corrects += i;
				DbConnection.SaveScore(
				new ScoreClass()
				{
					GameID = ReactionTest.GAMEID,
					ResidentID = CurrentUser.Id,
					TestDate = now,
					Score = corrects + Step
				});
			}
		}

		private void btAimTest_Click(object sender, EventArgs e)
		{
			AimTest test = new AimTest();
			test.ShowDialog();
			if (CurrentUser == null)
				return;
			DateTime now = DateTime.Today;
			foreach (long ticks in test.TimesInTicks)
			{
				DbConnection.SaveScore(
				new ScoreClass()
				{
					GameID = ReactionTest.GAMEID,
					ResidentID = CurrentUser.Id,
					TestDate = now,
					Score = float.Parse($"{ticks / 10000}.{test.Accuracy}")
				});
			}
		}

		private void btDashboard_Click(object sender, EventArgs e)
		{
			new Dashboard("").Show();
		}
	}
}
