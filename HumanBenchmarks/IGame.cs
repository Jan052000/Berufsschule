using HumanBenchmarks.Db.Classes;

namespace HumanBenchmarks
{
	internal interface IGame
	{
		string GameName { get; }
		int GameID { get; }
		ScoreClass ConvertToSpecificScore(ScoreClass score);
	}
}
