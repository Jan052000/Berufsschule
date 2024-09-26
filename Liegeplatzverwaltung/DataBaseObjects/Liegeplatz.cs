using Liegeplatzverwaltung.DataBaseUtils;
using Liegeplatzverwaltung.DataBaseUtils.Attributes;
using Liegeplatzverwaltung.DataGridViewUtils.Attributes;
using Liegeplatzverwaltung.Extensions;
using System.ComponentModel;

namespace Liegeplatzverwaltung.DataBaseObjects
{
	[Table("Liegeplatz")]
	public class Liegeplatz : DbBaseClass
	{
		[PrimaryKey("ID", AutoIncrement = true)]
		public long ID { get; private set; }
		[ForeignKey("Geparkt", typeof(Yacht), "KennNummer")]
		[DefaultValue("")]
		[DataGridColumn("Geparkt", typeof(DataGridViewTextBoxCell))]
		[AddLiegeplatz.DisableInputAtribute]
		public string YachtID { get; set; }
		[Column("Bezeichnung", true)]
		[DataGridColumn("Beschreibung", typeof(DataGridViewTextBoxCell))]
		public string? Description { get; set; }
		[Column("Kürzel")]
		[DataGridColumn("Kürzel", typeof(DataGridViewTextBoxCell))]
		public string? Short { get; set; }
		[Column("Breite")]
		[DataGridColumn("Breite", typeof(DataGridViewTextBoxCell))]
		public long? Width { get; set; }
		[Column("Laenge")]
		[DataGridColumn("Länge", typeof(DataGridViewTextBoxCell))]
		public long? Height { get; set; }
		[Column("Tiefe")]
		[DataGridColumn("Tiefe", typeof(DataGridViewTextBoxCell))]
		public long? Depth { get; set; }
		[Column("Bild")]
		[DefaultValue(new byte[0])]
		[DataGridColumn("Bild", typeof(DataGridViewImageCell), Readonly = true)]
		public byte[] Image { get; set; }
		[Column("Status")]
		[DefaultValue(typeof(Status), "Closed")]
		[StatusComboBoxColumn("Status")]
		public Status Status { get; set; }
	}
}
