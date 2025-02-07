using HumanBenchmarks.Db.Classes;
using HumanBenchmarks.Scores;

namespace HumanBenchmarks.Forms.Dashboard
{
	internal partial class ScoreControl : UserControl
	{
		private Dictionary<Type, List<(Func<List<ScoreClass>, string> Function, string MetricName)>> ScoreAverageFunctions = new Dictionary<Type, List<(Func<List<ScoreClass>, string> Function, string MetricName)>>
		{
			{
				typeof(AimTestScore), new List<(Func<List<ScoreClass>, string> Function, string MetricName)>
				{
					(score => Math.Round(score.Cast<AimTestScore>().Select(ats => ats.Accuracy).Average(), 2).ToString() + "%", "Genauigkeit"),
					(score => Math.Round(score.Cast<AimTestScore>().Select(ats => ats.TimeInMS).Average(), 2).ToString(), "Ziele")
				}
			},
			{
				typeof(ReactionTestScore), new List<(Func<List<ScoreClass>, string> Function, string MetricName)>
				{
					(score => Math.Round(score.Cast<ReactionTestScore>().Select(rts => rts.Score).Average() ?? -1, 2).ToString() + "MS", "Reaktionszeit")
				}
			},
			{
				typeof(SimonSaysScore), new List<(Func<List<ScoreClass>, string> Function, string MetricName)>
				{
					(score => Math.Round(score.Cast<SimonSaysScore>().Select(sss => sss.Rounds).Average(), 2).ToString(), "Runden"),
					(score => Math.Round(score.Cast < SimonSaysScore >().Select(sss => sss.Extra).Average(), 2).ToString(), "Runden Fortschritt"),
				}
			}
		};

		public ScoreControl(List<ScoreClass> scores, string game = "")
		{
			InitializeComponent();
			laTitle.Text = game;
			laAvgs.Text = "Durchschnitt";
			if (scores.Count == 0)
				return;
			Type scoreType = scores.First().GetType();
			DataGridViewUtils.DataGridViewUtils.GenerateColumns(dgvContent, scoreType);
			foreach (var score in scores)
			{
				DataGridViewUtils.DataGridViewUtils.AddItemToDataGridView(dgvContent, score, Color.White, Color.Black);
			}
			foreach (var item in ScoreAverageFunctions[scoreType])
			{
				flpAvgs.Controls.Add(new StatControl(item.MetricName, item.Function(scores)));
			}
		}
	}
}
