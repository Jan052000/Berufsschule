using Liegeplatzverwaltung.DataBaseUtils;
using Liegeplatzverwaltung.DataBaseUtils.Attributes;
using System.ComponentModel;

namespace Liegeplatzverwaltung.DataBaseObjects
{
	[Table("Liegeplatz")]
	public class Liegeplatz : DbBaseClass
	{
		[PrimaryKey("ID")]
		public int ID { get; set; }
		[ForeignKey("Geparkt", typeof(Yacht), "KennNummer")]
		[DefaultValue(-1)]
		public int YachtID { get; set; }
		[Column("Bezeichnung")]
		public string? Description { get; set; }
		[Column("Kürzel")]
		public string? Short { get; set; }
		[Column("Breite")]
		public int? Width { get; set; }
		[Column("Laenge")]
		public int? Height { get; set; }
		[Column("Tiefe")]
		public int? Depth { get; set; }
		[Column("Bild")]
		[DefaultValue(new byte[0])]
		public byte[] Image { get; set; }
		[Column("Status")]
		public int? Status { get; set; }
	}
}
