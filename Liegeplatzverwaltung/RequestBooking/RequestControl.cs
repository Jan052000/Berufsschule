using Liegeplatzverwaltung.Extensions;
using Liegeplatzverwaltung.FrontendConnection;

namespace Liegeplatzverwaltung.RequestBooking
{
	public partial class RequestControl : UserControl
	{
		private ResponseObject Data { get; }

		public delegate void RequestAssignedDelegate(RequestControl sender, string pierName, long pierID);
		public event RequestAssignedDelegate? RequestAssigned;

		public RequestControl(ResponseObject data)
		{
			InitializeComponent();
			laTitle.Text = $"{data.EMail} s' request";

			Data = data;
			tbIMO.Text = data.ShipUUID;
			tbMail.Text = data.EMail;
			tbType.Text = data.Type;
			nudDepth.Value = data.Depth;
			nudLength.Value = data.Length;
			nudWidth.Value = data.Width;
		}

		private void cbLiegeplatzOptions_DropDown(object sender, EventArgs e)
		{
			if (sender is not ComboBox cb)
				return;
			cb.Items.Clear();
			cb.Tag = DbProjectRequests.GetAllPossibleLiegeplätze(Data.Length, Data.Width, Data.Depth);
			foreach (var item in (List<(long ID, string Name)>)cb.Tag)
			{
				cb.Items.Add(item.Name);
			};
		}

		private void cbLiegeplatzOptions_SelectedValueChanged(object sender, EventArgs e)
		{
			if (sender is not ComboBox cb || MessageBox.Show($"Möchten sie {Data.EMail} zu {(sender as ComboBox)!.SelectedValue!} zuweisen?", "Zuweisen?", MessageBoxButtons.YesNo) != DialogResult.Yes)
				return;
			(long ID, string Name) selectedItem = (cb.Tag as List<(long ID, string Name)>).First(item => item.Name == (string)cb.SelectedItem);
			DbProjectRequests.UpdateLiegeplatzGeparkt(selectedItem.ID, Data);
			RequestAssigned?.Invoke(this, selectedItem.Name, selectedItem.ID);
		}
	}
}
