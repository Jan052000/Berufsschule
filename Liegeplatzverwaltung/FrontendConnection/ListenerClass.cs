using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Liegeplatzverwaltung.FrontendConnection
{
	internal class ListenerClass : IDisposable
	{
		private HttpListener? Listener { get; set; }
		private CancellationTokenSource? CancellationTokenSource { get; set; }
		private Task? MainLoopTask { get; set; }

		public delegate void Handler(ResponseObject responseObject, HttpListenerResponse response);
		private Handler ValueRecievedCallBack { get; }

		public ListenerClass() { }
		public ListenerClass(Handler valueRecievedCallBack)
		{
			ValueRecievedCallBack = valueRecievedCallBack;
		}

		public void Start()
		{
			Listener = new HttpListener();
			Listener.Prefixes.Add("http://localhost:6969/");
			Listener.Start();

			CancellationTokenSource = new CancellationTokenSource();

			MainLoopTask = new Task(async () => await MainLoop(CancellationTokenSource.Token));
			MainLoopTask.Start();
		}

		private async Task MainLoop(CancellationToken token)
		{
			try
			{
				while (!token.IsCancellationRequested)
				{
					HttpListenerContext ctx = Listener!.GetContext();
					await RecieveRequest(ctx);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		private async Task RecieveRequest(HttpListenerContext ctx)
		{
			Dictionary<string, string> queryValues = new Dictionary<string, string>();
			foreach (var key in ctx.Request.QueryString)
			{
				if (key is not string k)
					continue;
				if (k == "EMail" || k == "Type" || k == "Depth" || k == "Length" || k == "Width" || k == "IMO")
					queryValues.Add(k, ctx.Request.QueryString.Get(k));
			}

			bool missing = false;
			if (!queryValues.TryGetValue("EMail", out string mail) || mail is null)
			{
				missing = true;
				WriteErrorResponse(ctx.Response, "E-Mail fehlt");
			}
			if (!queryValues.TryGetValue("Type", out string type) || type is null)
			{
				missing = true;
				WriteErrorResponse(ctx.Response, "Schiffstyp fehlt");
			}
			if (!queryValues.TryGetValue("Depth", out string depthStr) || depthStr is null)
			{
				missing = true;
				WriteErrorResponse(ctx.Response, "Schiff Tiefgang fehlt");
			}
			if (!int.TryParse(depthStr, out int depth) || depth < 0)
			{
				missing = true;
				WriteErrorResponse(ctx.Response, "Ungültige tiefe");
			}
			if (!queryValues.TryGetValue("Length", out string lengthStr) || lengthStr is null)
			{
				missing = true;
				WriteErrorResponse(ctx.Response, "Schiff Länge fehlt");
			}
			if (!int.TryParse(lengthStr, out int length) || depth < 0)
			{
				missing = true;
				WriteErrorResponse(ctx.Response, "Ungültige Länge");
			}
			if (!queryValues.TryGetValue("Width", out string widthStr) || widthStr is null)
			{
				missing = true;
				WriteErrorResponse(ctx.Response, "Schiff Breite fehlt");
			}
			if (!int.TryParse(widthStr, out int width) || depth < 0)
			{
				missing = true;
				WriteErrorResponse(ctx.Response, "Ungültige Breite");
			}
			if (!queryValues.TryGetValue("IMO", out string shipUUID) || shipUUID is null)
			{
				missing = true;
				WriteErrorResponse(ctx.Response, "Schiff IMO fehlt");
			}
			if (missing)
			{
				ctx.Response.Close();
				return;
			}
			ValueRecievedCallBack(new ResponseObject(mail!, type!, depth, length, width, shipUUID!), ctx.Response);
		}

		private void WriteErrorResponse(HttpListenerResponse resp, string message)
		{
			if (resp.StatusCode != (int)HttpStatusCode.BadRequest)
				resp.StatusCode = (int)HttpStatusCode.BadRequest;
			if (resp.ContentType != "text/html")
				resp.ContentType = "text/html";
			byte[] messageB = Encoding.UTF8.GetBytes(message);
			resp.OutputStream.Write(messageB, 0, messageB.Count());
		}

		public void Dispose()
		{
			CancellationTokenSource?.Cancel();
			MainLoopTask?.GetAwaiter().GetResult();
			Listener?.Close();
		}
	}
}
