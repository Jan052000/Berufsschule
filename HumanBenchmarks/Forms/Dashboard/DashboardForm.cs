using HumanBenchmarks.Db;
using HumanBenchmarks.Db.Classes;
using HumanBenchmarks.Scores;

namespace HumanBenchmarks.Forms.Dashboard
{
	internal partial class DashboardForm : Form
	{
		private UserClass ActiveUser { get; }

		public DashboardForm(UserClass activeUser)
		{
			InitializeComponent();
			splitter1.Location = new Point(Width / 3, 0);
			splitter2.Location = new Point((Width / 3) * 2, 0);

			ActiveUser = activeUser;

			List<ScoreClass> scores = DbConnection.GetTestScores(activeUser);
			paReactionTime.Controls.Add(new ScoreControl(scores.Where(score => score is ReactionTestScore).ToList()) { Dock = DockStyle.Fill });
			paSimonSays.Controls.Add(new ScoreControl(scores.Where(score => score is SimonSaysScore).ToList()) { Dock = DockStyle.Fill });
			paAimTest.Controls.Add(new ScoreControl(scores.Where(score => score is AimTestScore).ToList()) { Dock = DockStyle.Fill });
		}
	}
}
