using Liegeplatzverwaltung.DataBaseUtils;
using Liegeplatzverwaltung.DataBaseUtils.Attributes;

namespace Liegeplatzverwaltung.DataBaseObjects
{
	[Table("Yacht")]
	public class Yacht : DbBaseClass
	{
		[PrimaryKey("KennNummer", AutoIncrement = true)]
		public long ID { get; }
		[ForeignKey("Besitzer", typeof(Besitzer), "UUID")]
		public long OwnerID { get; set; }
		[Column("Name")]
		public string Name { get; set; }
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
