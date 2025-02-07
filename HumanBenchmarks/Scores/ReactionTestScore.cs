using DataGridViewUtils.Attributes;
using HumanBenchmarks.Db.Classes;

namespace HumanBenchmarks.Scores
{
	internal class ReactionTestScore : ScoreClass
	{
		[DataGridColumn("Reaktionszeit MS", typeof(DataGridViewTextBoxCell), Readonly = true)]
		public new double? Score { get => base.Score; set => base.Score = value; }

		public ReactionTestScore(ScoreClass score) : base()
		{
			ID = score.ID;
			ResidentID = score.ResidentID;
			Score = score.Score;
			TestDate = score.TestDate;
			GameID = score.GameID;
		}
	}
}
