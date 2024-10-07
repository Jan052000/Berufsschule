using Liegeplatzverwaltung.Extensions;
using Liegeplatzverwaltung.FrontendConnection;
using System.Net;

namespace Liegeplatzverwaltung.RequestBooking
{
	public partial class BookingRequests : Form
	{
		public delegate void LiegeplatzAssignedDelegate(ResponseObject obj);
		public event LiegeplatzAssignedDelegate? LiegeplatzAssigned;

		public BookingRequests(Dictionary<ResponseObject, HttpListenerResponse> requestData)
		{
			InitializeComponent();
			this.SetIcon();

			foreach (KeyValuePair<ResponseObject, HttpListenerResponse> kvp in requestData)
			{
				RequestControl request = new RequestControl(kvp.Key);
				request.RequestAssigned += (sender, pierName, pierID) =>
				{
					flpRequestControls.Controls.Remove(sender);
					ListenerClass.WriteSuccessResponse(kvp.Value, pierName);
					LiegeplatzAssigned?.Invoke(kvp.Key);
				};
				flpRequestControls.Controls.Add(request);
			}
			this.SetTheme();
		}
	}
}
