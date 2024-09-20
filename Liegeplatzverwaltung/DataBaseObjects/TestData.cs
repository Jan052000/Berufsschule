using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
					Name = "AWW MAN",
					OwnerID = 0,
					ShipType = "U-Boot",
					Width = 20
				},
				new Yacht()
				{
					Depth = 55,
					Height = 150,
					Name = "Creeper",
					OwnerID = 1,
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
					Status = 0,
					Width = 35,
					YachtID = -1
				},
				new Liegeplatz()
				{
					Depth = 25,
					Description = "Pier 1",
					Height = 30,
					Image = [],
					Short = "1",
					Status = -1,
					Width = 35,
					YachtID = -1
				},
				new Liegeplatz()
				{
					Depth = 55,
					Description = "Pier 2",
					Height = 150,
					Image = [],
					Short = "1",
					Status = 1,
					Width = 35,
					YachtID = 0
				},
				new Liegeplatz()
				{
					Depth = 5,
					Description = "Pier 3",
					Height = 900,
					Image = [],
					Short = "3",
					Status = 0,
					Width = 35,
					YachtID = -1
				}
			};
			return liegeplaetze;
		}
	}
}
