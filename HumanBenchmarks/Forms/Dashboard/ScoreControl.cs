using HumanBenchmarks.Db.Classes;

namespace HumanBenchmarks.Forms.Dashboard
{
	internal partial class ScoreControl : UserControl
	{
		public ScoreControl(List<ScoreClass> scores, string game = "")
		{
			InitializeComponent();
			laTitle.Text = game;
			if (scores.Count == 0)
				return;
			DataGridViewUtils.DataGridViewUtils.GenerateColumns(dgvContent, scores.First());
			foreach (var score in scores)
			{
				DataGridViewUtils.DataGridViewUtils.AddItemToDataGridView(dgvContent, score, Color.White, Color.Black);
			}
		}
	}
}
