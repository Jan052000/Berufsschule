using DataGridViewUtils.Attributes;
using HumanBenchmarks.Db.Classes;

namespace HumanBenchmarks.Scores
{
	internal class AimTestScore : ScoreClass
	{
		[DataGridColumn("Genauigkeit %", typeof(DataGridViewTextBoxCell), Readonly = true)]
		public double Accuracy => BreakUpScore().Accuracy;
		[DataGridColumn("Ziele", typeof(DataGridViewTextBoxCell), Readonly = true)]
		public int Targets => BreakUpScore().Targets;

		public AimTestScore(ScoreClass score)
		{
			ID = score.ID;
			ResidentID = score.ResidentID;
			Score = score.Score;
			TestDate = score.TestDate;
			GameID = score.GameID;
		}

		private (double Accuracy, int Targets) BreakUpScore()
		{
			(double a, int t) res = (0, 0);

			res.t = (int?)Score ?? 0 * 10 / 10;
			if (Score is double score)
				res.a = (score - Math.Floor(score)) * 1000;
			res.a = Math.Round(res.a, 2);

			return res;
		}
	}
}
