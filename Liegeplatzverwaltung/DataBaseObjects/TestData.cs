namespace Liegeplatzverwaltung.DataBaseObjects
{
	public class TestData
	{
		public static List<Besitzer> GetBesitzerData()
		{
			return new List<Besitzer>
			{
				new Besitzer()
				{
					Address = "Juckt",
					EMail = "Test@Test.Test",
					Name = "das an",
					Phone = "0",
					SurName = "Was geht sie"
				},
				new Besitzer()
				{
					Address = "faul",
					EMail = "faul",
					Name = "faul",
					Phone = "1",
					SurName = "zu"
				}
			};
		}

		public static List<Yacht> GetYachtData()
		{
			return new List<Yacht>()
			{
				new Yacht()
				{
					Depth = 15,
					Height = 5,
					ID = "EWWWWWWW",
					OwnerMail = "t@t.t",
					ShipType = "U-Boot",
					Width = 20
				},
				new Yacht()
				{
					Depth = 55,
					Height = 150,
					ID = "KW-OW-KA-PO-W",
					OwnerMail = "mr.wasgeht@siedas.an",
					ShipType = "Schlachtkreuzer",
					Width = 50
				}
			};
		}

		public static List<Liegeplatz> GetLiegeplatzData()
		{
			List<Liegeplatz> liegeplaetze = new List<Liegeplatz>
			{
				new Liegeplatz()
				{
					Depth = 5,
					Description = "Pier 0",
					Height = 900,
					Image = [],
					Short = "0",
					Status = Status.Open,
					Width = 35,
					YachtID = ""
				},
				new Liegeplatz()
				{
					Depth = 25,
					Description = "Pier 1",
					Height = 30,
					Image = [],
					Short = "1",
					Status = Status.Closed,
					Width = 35,
					YachtID = ""
				},
				new Liegeplatz()
				{
					Depth = 55,
					Description = "Pier 2",
					Height = 150,
					Image = [],
					Short = "1",
					Status = Status.Occupied,
					Width = 35,
					YachtID = GetYachtData()[0].ID
				},
				new Liegeplatz()
				{
					Depth = 5,
					Description = "Pier 3",
					Height = 900,
					Image = [],
					Short = "3",
					Status = Status.Rented,
					Width = 35,
					YachtID = ""
				}
			};
			return liegeplaetze;
		}
	}
}
