using DataGridViewUtils.Attributes;
using HumanBenchmarks.Db.Classes;

namespace HumanBenchmarks.Scores
{
	internal class SimonSaysScore : ScoreClass
	{
		[DataGridColumn("Runden", typeof(DataGridViewTextBoxCell), Readonly = true)]
		public double Rounds => ReverseSum().Rounds;
		[DataGridColumn("Treffer", typeof(DataGridViewTextBoxCell), Readonly = true)]
		public double Extra => ReverseSum().Extra;

		public SimonSaysScore(ScoreClass score)
		{
			ID = score.ID;
			ResidentID = score.ResidentID;
			Score = score.Score;
			TestDate = score.TestDate;
			GameID = score.GameID;
		}

		private (double Rounds, double Extra) ReverseSum()
		{
			(double rounds, double extra) res = (0, 0);

			int handled = 0;
			for (int i = 1; i < Score; i++)
			{
				if (i + handled > Score)
					break;
				handled += i;
				res.rounds++;
			}
			res.extra = Score - handled ?? 0;

			return res;
		}
	}
}
