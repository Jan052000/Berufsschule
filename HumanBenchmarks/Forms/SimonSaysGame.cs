namespace HumanBenchmarks.Forms
{
	internal partial class SimonSaysGame : Form
	{
		private int NextIndex = -1;
		private bool GameStarted = false;
		private bool Flashing = false;
		private List<Point> GameSteps { get; } = new List<Point>();
		private Dictionary<Point, Button> Buttons { get; } = new Dictionary<Point, Button>();
		private int GameSize { get; set; } = -1;
		private int InitialGameSize { get; set; } = 3;
		private int FlashIntervalMS => 1000;
		private Color FlashColor => Color.Blue;
		private Color ButtonBackColor => SystemColors.ControlDark;
		public List<(int Round, int Step)> Results { get; } = new List<(int Round, int Step)>();

		public SimonSaysGame()
		{
			InitializeComponent();
			SetupGame(InitialGameSize);
			nudSize.Value = InitialGameSize;
		}

		private void Reset()
		{
			GameSteps.Clear();
			nudRound.Value = 0;
			NextIndex = -1;
		}

		private void SetupGame(int size)
		{
			Reset();
			if (size == GameSize)
				return;
			GameSize = size;

			tlpGame.SuspendLayout();
			foreach (Button b in Buttons.Values)
			{
				b.Click -= Clicked;
				tlpGame.Controls.Remove(b);
			}
			Buttons.Clear();

			tlpGame.ColumnStyles.Clear();
			tlpGame.RowStyles.Clear();
			tlpGame.ColumnCount = tlpGame.RowCount = GameSize;

			for (int y = 0; y < GameSize; y++)
			{
				for (int x = 0; x < GameSize; x++)
				{
					Button bt = new Button();
					bt.Text = "";
					bt.Dock = DockStyle.Fill;
					bt.FlatStyle = FlatStyle.Flat;
					bt.FlatAppearance.BorderSize = 0;
					bt.BackColor = ButtonBackColor;
					bt.Click += Clicked;
					tlpGame.Controls.Add(bt);
					tlpGame.SetRow(bt, y);
					tlpGame.SetColumn(bt, x);
					Buttons.Add(new Point(x, y), bt);
				}
			}

			float eSize = 100 / GameSize;
			for (int i = 0; i < tlpGame.RowCount; i++)
				tlpGame.RowStyles.Add(new RowStyle(SizeType.Percent, eSize));
			for (int i = 0; i < tlpGame.ColumnCount; i++)
				tlpGame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, eSize));

			tlpGame.ResumeLayout();
		}

		private void btRegenField_Click(object? sender, EventArgs e)
		{
			SetupGame((int)nudSize.Value);
		}

		private async void Clicked(object? sender, EventArgs e)
		{
			if (!GameStarted || Flashing || sender is not Button bt)
				return;
			//Disable();
			Point buttonPos = new Point(tlpGame.GetColumn(bt), tlpGame.GetRow(bt));

			Interlocked.Increment(ref NextIndex);
			if (!buttonPos.Equals(GameSteps[NextIndex]))
			{
				GameOver();
				return;
			}
			if (NextIndex == GameSteps.Count - 1)
			{
				await NextGameRoundAsync();
			}

			//Enable();
		}

		private void GameOver()
		{
			foreach (Button b in Buttons.Values)
				b.BackColor = Color.Red;
			GameStarted = false;
			Results.Add((Round: (int)nudRound.Value, Step: NextIndex));
		}

		/*
		private void Enable()
		{
			foreach (Button b in Buttons.Values)
				if (b.InvokeRequired)
					b.Invoke(() => b.Enabled = true);
				else
					b.Enabled = true;
		}

		private void Disable()
		{
			foreach (Button b in Buttons.Values)
				if (b.InvokeRequired)
					b.Invoke(() => b.Enabled = false);
				else
					b.Enabled = false;
		}

		private void NextGameRound()
		{
			Flashing = true;
			int nextButtonPointIndex = new Random().Next(0, Buttons.Keys.Count);
			GameSteps.Add(Buttons.Keys.ToList()[nextButtonPointIndex]);
			foreach (Point p in GameSteps)
			{
				Button b = Buttons[p];
				b.BackColor = FlashColor;
				Task.Delay(FlashIntervalMS).GetAwaiter().GetResult();
				b.BackColor = ButtonBackColor;
			}
			nudRound.Value++;
			NextIndex = -1;
			Flashing = false;
		}
		*/

		private Task NextGameRoundAsync()
		{
			Flashing = true;
			int nextButtonPointIndex = new Random().Next(0, Buttons.Keys.Count);
			GameSteps.Add(Buttons.Keys.ToList()[nextButtonPointIndex]);
			Interlocked.Exchange(ref NextIndex, -1);
			return Task.Run(async () =>
			{
				for (int i = 0; i < GameSteps.Count; i++)
				{
					Point p = GameSteps[i];
					Button b = Buttons[p];
					if (b.InvokeRequired)
						b.Invoke(() => b.BackColor = FlashColor);
					else
						b.BackColor = FlashColor;
					await Task.Delay(FlashIntervalMS);
					if (b.InvokeRequired)
						b.Invoke(() => b.BackColor = ButtonBackColor);
					else
						b.BackColor = ButtonBackColor;
					if (i != GameSteps.Count - 1)
						await Task.Delay(500);
				}
				if (nudRound.InvokeRequired)
					nudRound.Invoke(() => nudRound.Value++);
				else
					nudRound.Value++;
				Flashing = false;
			});
		}

		private async void StartGame(object sender, EventArgs e)
		{
			if (Flashing)
				return;
			//Enable();
			Reset();
			foreach (Button b in Buttons.Values)
				b.BackColor = ButtonBackColor;
			GameStarted = true;
			await NextGameRoundAsync();
		}
	}

	internal class TestTableLayoutPanel : TableLayoutPanel
	{
		public TestTableLayoutPanel()
		{
			DoubleBuffered = true;
		}
	}
}
