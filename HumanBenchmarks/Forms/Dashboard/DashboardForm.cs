using HumanBenchmarks.Db;
using HumanBenchmarks.Db.Classes;
using HumanBenchmarks.Scores;

namespace HumanBenchmarks.Forms.Dashboard
{
	internal partial class DashboardForm : Form
	{
		private UserClass? ActiveUser { get; }
		private List<ScoreClass> Scores { get; } = new List<ScoreClass>();

		public DashboardForm(UserClass activeUser)
		{
			InitializeComponent();
			Setup();

			ActiveUser = activeUser;

			AddFilteredControls();
		}

		public DashboardForm(List<ScoreClass> scores)
		{
			InitializeComponent();
			Setup();
			Scores = scores;

			AddFilteredControls();
		}

		private void Setup()
		{
			dtpStart.MinDate = dtpEnd.MinDate = DateTime.MinValue;
			dtpStart.Value = dtpStart.MinDate;
			dtpStart.MaxDate = dtpEnd.MaxDate = DateTime.MaxValue;
			dtpEnd.Value = dtpEnd.MaxDate;

			dtpStart.ValueChanged += DateTimeChanged;
			dtpEnd.ValueChanged += DateTimeChanged;
		}

		public void UpdateScores()
		{
			AddFilteredControls();
		}

		private void AddFilteredControls()
		{
			List<ScoreClass> n;
			if (ActiveUser == null)
				n = Scores.Where(score => dtpStart.Value.Date <= score.TestDate && score.TestDate <= dtpEnd.Value.Date).ToList();
			else
				n = DbConnection.GetTestScores(ActiveUser, dtpStart.Value.Date, dtpEnd.Value.Date);
			paReactionTime.Controls.Clear();
			paReactionTime.Controls.Add(new ScoreControl(n.Where(score => score is ReactionTestScore).ToList(), ReactionTest.GAMENAME) { Dock = DockStyle.Fill });
			paSimonSays.Controls.Clear();
			paSimonSays.Controls.Add(new ScoreControl(n.Where(score => score is SimonSaysScore).ToList(), SimonSaysGame.GAMENAME) { Dock = DockStyle.Fill });
			paAimTest.Controls.Clear();
			paAimTest.Controls.Add(new ScoreControl(n.Where(score => score is AimTestScore).ToList(), AimTest.GAMENAME) { Dock = DockStyle.Fill });
		}

		private void DateTimeChanged(object? sender, EventArgs e)
		{
			AddFilteredControls();
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			dtpStart.ValueChanged -= DateTimeChanged;
			dtpEnd.ValueChanged -= DateTimeChanged;
		}
	}
}
