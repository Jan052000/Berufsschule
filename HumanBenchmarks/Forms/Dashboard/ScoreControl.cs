using HumanBenchmarks.Db.Classes;

namespace HumanBenchmarks.Forms.Dashboard
{
	internal partial class ScoreControl : UserControl
	{
		private bool IsUpdatingSelection { get; set; } = false;
		public ScoreControl(List<ScoreClass> scores)
		{
			InitializeComponent();
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
