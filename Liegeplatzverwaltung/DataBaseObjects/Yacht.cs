using Liegeplatzverwaltung.DataBaseUtils;
using Liegeplatzverwaltung.DataBaseUtils.Attributes;

namespace Liegeplatzverwaltung.DataBaseObjects
{
	[Table("Yacht")]
	public class Yacht : DbBaseClass
	{
		[PrimaryKey("KennNummer")]
		public string ID { get; set; }
		[Column("BesitzerMail")]
		public string OwnerMail { get; set; }
		[Column("Breite")]
		public long? Width { get; set; }
		[Column("Laenge")]
		public long? Height { get; set; }
		[Column("Tiefe")]
		public long? Depth { get; set; }
		[Column("Schifftyp")]
		public string ShipType { get; set; }
	}
}
