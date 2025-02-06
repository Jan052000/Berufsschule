using DataBaseUtils;
using HumanBenchmarks.Db.Classes;
using HumanBenchmarks.Forms;
using System.Data.Common;
using System.Data.SQLite;

namespace HumanBenchmarks.Db
{
	internal class DbConnection
	{
		private const string DBFILENAME = "HumanBenchmarks.db";
		private static string DbPath => Path.GetFullPath($"./{DBFILENAME}");
		internal static string ConnectionString => $"Data Source={DbPath}; Version=3";

		/// <summary>
		/// Generates a new <see cref="SQLiteConnection"/> and opens it
		/// </summary>
		/// <returns>An opened <see cref="SQLiteConnection"/></returns>
		internal static SQLiteConnection GetSQLiteConnection()
		{
			SQLiteConnection conn = new SQLiteConnection(ConnectionString);
			conn.Open();
			return conn;
		}

		public static readonly IDbTypeSwitch DbDialect = new SQLiteDialect();

		internal static void InitDB()
		{
			if (File.Exists(DbPath))
				return;
			using var conn = GetSQLiteConnection();
			using (DbCommand cmd = conn.CreateCommand())
			{
				cmd.CommandText = DbUtils.GetCreateCommand<UserClass>(DbDialect);
				cmd.ExecuteNonQuery();
			}
			using (DbCommand cmd = conn.CreateCommand())
			{
				cmd.CommandText = DbUtils.GetCreateCommand<ScoreClass>(DbDialect);
				cmd.ExecuteNonQuery();
			}

			List<UserClass> users = new List<UserClass>()
			{
				new UserClass()
				{
					FirstName = "Gladis",
					LastName = "Bauer",
					BirthDay = new DateTime(1920, 12, 24),
					Id = 0
				},
				new UserClass()
				{
					FirstName = "Harald",
					LastName = "Harald",
					BirthDay = new DateTime(1900, 1, 1),
					Id = 1
				},
				new UserClass()
				{
					FirstName = "Henri",
					LastName = "Henrison",
					BirthDay=new DateTime(2019, 4, 5),
					Id = 2
				}
			};
			using (DbCommand cmd = conn.CreateCommand())
			{
				cmd.CommandText = DbUtils.GetFillTableWithDataCommand(users, DbDialect);
				cmd.ExecuteNonQuery();
			}

			List<ScoreClass> scores = new List<ScoreClass>()
			{
				new ScoreClass()
				{
					ID = 0,
					GameID = SimonSaysGame.GAMEID,
					ResidentID = users[2].Id,
					Score = -300,
					TestDate = new DateTime(2019, 4, 6)
				},
				new ScoreClass()
				{
					ID = 1,
					GameID = AimTest.GAMEID,
					ResidentID = users[2].Id,
					Score = -999,
					TestDate = new DateTime(2019, 4, 6)
				},
				new ScoreClass()
				{
					ID = 2,
					GameID = ReactionTest.GAMEID,
					ResidentID = users[2].Id,
					Score = 30000,
					TestDate = new DateTime(2019, 4, 6)
				},
				new ScoreClass()
				{
					ID = 3,
					GameID = AimTest.GAMEID,
					ResidentID = users[0].Id,
					Score = 1230,
					TestDate = new DateTime(2025, 2, 6)
				},
				new ScoreClass()
				{
					ID = 4,
					GameID = ReactionTest.GAMEID,
					ResidentID = users[0].Id,
					Score = 120,
					TestDate = new DateTime(2025, 2, 6)
				}
			};
			using (DbCommand cmd = conn.CreateCommand())
			{
				cmd.CommandText = DbUtils.GetFillTableWithDataCommand(scores, DbDialect);
				cmd.ExecuteNonQuery();
			}
		}

		public static void SaveScore(ScoreClass score)
		{
			using var conn = GetSQLiteConnection();
			using var cmd = conn.CreateCommand();
			cmd.CommandText = DbUtils.GetInsertCommand(score, DbDialect);
			cmd.ExecuteNonQuery();
		}
	}
}
