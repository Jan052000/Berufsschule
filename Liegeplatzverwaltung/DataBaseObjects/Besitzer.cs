using Liegeplatzverwaltung.DataBaseUtils;
using Liegeplatzverwaltung.DataBaseUtils.Attributes;

namespace Liegeplatzverwaltung.DataBaseObjects
{
	[Table("Besitzer")]
	public class Besitzer : DbBaseClass
	{
		[PrimaryKey("ID", AutoIncrement = true)]
		public long ID { get; }
		//[Column("Name")]
		//public string SurName { get; set; }
		//[Column("Vorname")]
		//public string Name { get; set; }
		//[Column("Adresse")]
		//public string Address { get; set; }
		//[Column("Telefon")]
		//public string Phone { get; set; }
		[Column("EMail")]
		public string EMail { get; set; }
	}
}
