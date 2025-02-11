namespace Liegeplatzverwaltung.FrontendConnection
{
	public class ResponseObject
	{
		public string EMail { get; }
		public string Type { get; }
		public int Depth { get; }
		public int Length { get; }
		public int Width { get; }
		public string ShipUUID { get; }

		internal ResponseObject(string eMail, string type, int depth, int length, int width, string shipUUID)
		{
			EMail = eMail;
			Type = type;
			Depth = depth;
			Length = length;
			Width = width;
			ShipUUID = shipUUID;
		}
	}
}
