using Liegeplatzverwaltung.DataBaseUtils;
using Liegeplatzverwaltung.DataBaseUtils.Attributes;

namespace Liegeplatzverwaltung.DataBaseObjects
{
	[Table("Yacht")]
	public class Yacht : DbBaseClass
	{
		[PrimaryKey("KennNummer")]
		public string ID { get; set; }
		[ForeignKey("OwnerID", typeof(Besitzer), "ID")]
		public long OwnerID { get; set; }
		[Column("Breite")]
		public long? Width { get; set; }
		[Column("Laenge")]
		public long? Height { get; set; }
		[Column("Tiefe")]
		public long? Depth { get; set; }
		[Column("Länge")]
		public long? Length { get; set; }
		[Column("Schifftyp")]
		public string ShipType { get; set; }
	}
}
