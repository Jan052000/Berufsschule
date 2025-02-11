using HumanBenchmarks.Db;
using HumanBenchmarks.Db.Classes;
using HumanBenchmarks.Forms.Dashboard;

namespace HumanBenchmarks.Forms
{
	internal partial class MainForm : Form
	{
		public UserClass? CurrentUser { get; private set; }
		private string TextCache { get; set; }
		private DashboardForm? DashboardForm { get; set; }
		private List<ScoreClass> LocalScoreCache { get; } = [];

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

		private void SaveScore(ScoreClass score, IGame game)
		{
			if (CurrentUser == null)
				LocalScoreCache.Add(game.ConvertToSpecificScore(score));
			else
				DbConnection.SaveScore(score);
		}

		private void btReactionCheck_Click(object sender, EventArgs e)
		{
			ReactionTest test = new ReactionTest();
			test.ShowDialog();
			DateTime today = DateTime.Today;
			foreach (int score in test.Results)
			{
				ScoreClass scoreCl = new ScoreClass()
				{
					GameID = test.GameID,
					ResidentID = CurrentUser?.Id,
					TestDate = today,
					Score = score
				};
				SaveScore(scoreCl, test);
			}
			DashboardForm?.UpdateScores();
		}

		private void btSimonSays_Click(object sender, EventArgs e)
		{
			SimonSaysGame test = new SimonSaysGame();
			test.ShowDialog();
			DateTime today = DateTime.Today;
			foreach ((int Round, int Step) in test.Results)
			{
				int corrects = 0;
				for (int i = 1; i < Round; i++)
					corrects += i;
				ScoreClass score = new ScoreClass()
				{
					GameID = test.GameID,
					ResidentID = CurrentUser?.Id,
					TestDate = today,
					Score = corrects + Step
				};
				SaveScore(score, test);
			}
			DashboardForm?.UpdateScores();
		}

		private void btAimTest_Click(object sender, EventArgs e)
		{
			AimTest test = new AimTest();
			test.ShowDialog();
			DateTime today = DateTime.Today;
			if (!test.GameStarted)
				return;
			double accuracy = Math.Round(test.Accuracy * 10000, 0);
			ScoreClass score = new ScoreClass()
			{
				GameID = test.GameID,
				ResidentID = CurrentUser?.Id,
				TestDate = today,
				Score = double.Parse($"{Math.Round(test.TimesInTicks.Average() / 10000, 0)}.{(accuracy < 100 ? $"0{accuracy}" : accuracy)}", System.Globalization.CultureInfo.InvariantCulture)
			};
			SaveScore(score, test);
			DashboardForm?.UpdateScores();
		}

		private void btDashboard_Click(object sender, EventArgs e)
		{
			if (DashboardForm != null)
				return;
			if (CurrentUser == null)
				DashboardForm = new DashboardForm(LocalScoreCache);
			else
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
			//btDashboard.Enabled = CurrentUser != null;
			if (CurrentUser == null)
				Text = TextCache;
			else
				Text = $"{TextCache} User: {CurrentUser.Id}";
		}

		private void btLogout_Click(object sender, EventArgs e)
		{
			DashboardForm?.Close();
			LocalScoreCache.Clear();
			Hide();
			DoLogin();
			Show();
		}
	}
}
