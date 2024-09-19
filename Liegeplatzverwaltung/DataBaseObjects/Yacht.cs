using Liegeplatzverwaltung.DataBaseUtils;
using Liegeplatzverwaltung.DataBaseUtils.Attributes;

namespace Liegeplatzverwaltung.DataBaseObjects
{
	[Table("Yacht")]
	public class Yacht : DbBaseClass
	{
		[PrimaryKey("KennNummer")]
		public int ID { get; set; }
		[ForeignKey("Besitzer", typeof(Besitzer), "UUID")]
		public int OwnerID { get; set; }
		[Column("Name")]
		public string Name { get; set; }
		[Column("Breite")]
		public int? Width { get; set; }
		[Column("Laenge")]
		public int? Height { get; set; }
		[Column("Tiefe")]
		public int? Depth { get; set; }
		[Column("Schifftyp")]
		public string ShipType { get; set; }
	}
}
