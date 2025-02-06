using HumanBenchmarks.Db.Classes;

namespace HumanBenchmarks.Forms
{
	internal partial class RegisterForm : Form
	{
		public UserClass? NewUser { get; set; }

		public RegisterForm(long id)
		{
			InitializeComponent();
			nudID.Maximum = decimal.MaxValue;
			nudID.Value = id;
		}

		private void btRegister_Click(object sender, EventArgs e)
		{
			NewUser = new UserClass()
			{
				BirthDay = dtpBirthday.Value,
				FirstName = tbFirstName.Text,
				LastName = tbLastName.Text,
				Id = (int)nudID.Value
			};
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
