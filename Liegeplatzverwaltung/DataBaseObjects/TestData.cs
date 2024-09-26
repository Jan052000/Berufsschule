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
					//Address = "Juckt",
					EMail = "mr.wasgehtsie@das.an",
					//Name = "das an",
					//Phone = "0",
					//SurName = "Was geht sie"
				},
				new Besitzer()
				{
					//Address = "faul",
					EMail = "faul",
					//Name = "faul",
					//Phone = "1",
					//SurName = "zu"
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
					Length = 7,
					Height = 5,
					ID = "EWWWWWWW",
					OwnerID = 0,
					ShipType = "U-Boot",
					Width = 20
				},
				new Yacht()
				{
					Depth = 115,
					Height = 330,
					ID = "AWW MAN",
					Length = 1600,
					OwnerID = 0,
					ShipType = "Sternenzerstörer",
					Width = 985
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
