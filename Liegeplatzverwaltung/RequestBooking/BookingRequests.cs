using Liegeplatzverwaltung.Extensions;
using Liegeplatzverwaltung.FrontendConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
		}
	}
}
