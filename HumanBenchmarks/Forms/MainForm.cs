namespace HumanBenchmarks.Forms
{
	internal partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void btClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btReactionCheck_Click(object sender, EventArgs e)
		{
			ReactionTest test = new ReactionTest();
			test.ShowDialog();
		}

		private void btSimonSays_Click(object sender, EventArgs e)
		{
			SimonSaysGame test = new SimonSaysGame();
			test.ShowDialog();
		}

		private void btAimTest_Click(object sender, EventArgs e)
		{
			AimTest test = new AimTest();
			test.ShowDialog();
		}
	}
}
