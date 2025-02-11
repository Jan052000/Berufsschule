using HumanBenchmarks.Db;
using HumanBenchmarks.Db.Classes;
using HumanBenchmarks.Forms.Dashboard;

namespace HumanBenchmarks.Forms
{
	internal partial class MainForm : Form
	{
		public UserClass? CurrentUser { get; set; }
		private string TextCache { get; set; }
		private DashboardForm? DashboardForm { get; set; }

		public MainForm()
		{
			DbConnection.InitDB();
			InitializeComponent();
			TextCache = Text;
			DoLogin();
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
			DashboardForm?.UpdateScores();
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
					GameID = SimonSaysGame.GAMEID,
					ResidentID = CurrentUser.Id,
					TestDate = now,
					Score = corrects + Step
				});
			}
			DashboardForm?.UpdateScores();
		}

		private void btAimTest_Click(object sender, EventArgs e)
		{
			AimTest test = new AimTest();
			test.ShowDialog();
			if (CurrentUser == null)
				return;
			DateTime now = DateTime.Today;
			if (!test.GameStarted)
				return;
			double accuracy = Math.Round(test.Accuracy * 10000, 0);
			DbConnection.SaveScore(
			new ScoreClass()
			{
				GameID = AimTest.GAMEID,
				ResidentID = CurrentUser.Id,
				TestDate = now,
				Score = double.Parse($"{Math.Round(test.TimesInTicks.Average() / 10000, 0)}.{(accuracy < 100 ? $"0{accuracy}" : accuracy)}", System.Globalization.CultureInfo.InvariantCulture)
			});
			DashboardForm?.UpdateScores();
		}

		private void btDashboard_Click(object sender, EventArgs e)
		{
			if (CurrentUser == null || DashboardForm != null)
				return;
			DashboardForm = new DashboardForm(CurrentUser);
			DashboardForm.FormClosed += (s, e) => DashboardForm = null;
			DashboardForm.Show();
		}

		private void DoLogin()
		{
			CurrentUser = null;
			LoginForm login = new LoginForm();
			login.ShowDialog();
			CurrentUser = login.User;
			btDashboard.Enabled = CurrentUser != null;
			if (CurrentUser == null)
				Text = TextCache;
			else
				Text = $"{TextCache} User: {CurrentUser.Id}";
		}

		private void btLogout_Click(object sender, EventArgs e)
		{
			DashboardForm?.Close();
			Hide();
			DoLogin();
			Show();
		}
	}
}
