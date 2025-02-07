using DataBaseUtils;
using DataBaseUtils.Attributes;

namespace HumanBenchmarks.Db.Classes
{
	[Table("Ergebnisse")]
	internal class ScoreClass : DbBaseClass
	{
		[PrimaryKey("TestID", AutoIncrement = true)]
		public long? ID { get; set; }
		[ForeignKey("BewohnerNR", typeof(UserClass), "BewohnerNR")]
		public long? ResidentID { get; set; }
		[Column("Ergebnis")]
		public double? Score { get; set; }
		[Column("SpielID")]
		public long? GameID { get; set; }
		[Column("TestDatum")]
		public DateTime? TestDate { get; set; }
	}
}
