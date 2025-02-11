using DataBaseUtils;
using DataBaseUtils.Attributes;

namespace HumanBenchmarks.Db.Classes
{
	[Table("Nutzer")]
	internal class UserClass : DbBaseClass
	{
		[PrimaryKey("BewohnerNR", AutoIncrement = true)]
		public long? Id { get; set; }
		[Column("VorName")]
		public string? FirstName { get; set; }
		[Column("NachName")]
		public string? LastName { get; set; }
		[Column("Geburtstag")]
		public DateTime? BirthDay { get; set; }
	}
}
