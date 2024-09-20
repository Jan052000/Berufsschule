using Liegeplatzverwaltung.DataBaseUtils;
using Liegeplatzverwaltung.DataBaseUtils.Attributes;
using Liegeplatzverwaltung.DataGridViewUtils.Attributes;
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
		[DataGridColumn("Geparkt", typeof(DataGridViewTextBoxCell))]
		public int YachtID { get; set; }
		[Column("Bezeichnung")]
		[DataGridColumn("Beschreibung", typeof(DataGridViewTextBoxCell))]
		public string? Description { get; set; }
		[Column("Kürzel")]
		[DataGridColumn("Kürzel", typeof(DataGridViewTextBoxCell))]
		public string? Short { get; set; }
		[Column("Breite")]
		[DataGridColumn("Breite", typeof(DataGridViewTextBoxCell))]
		public int? Width { get; set; }
		[Column("Laenge")]
		[DataGridColumn("Länge", typeof(DataGridViewTextBoxCell))]
		public int? Height { get; set; }
		[Column("Tiefe")]
		[DataGridColumn("Tiefe", typeof(DataGridViewTextBoxCell))]
		public int? Depth { get; set; }
		[Column("Bild")]
		[DefaultValue(new byte[0])]
		public byte[] Image { get; set; }
		[Column("Status")]
		[DataGridColumn("Status", typeof(DataGridViewComboBoxCell))]
		public int? Status { get; set; }
	}
}
