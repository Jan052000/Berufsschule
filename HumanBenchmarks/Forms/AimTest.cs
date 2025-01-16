namespace HumanBenchmarks.Forms
{
	internal partial class AimTest : Form
	{
		private const int TARGETSIZE = 25;
		private const int SPAWNDELAY = 100;

		private int _Clicks = 0;
		private int _Hits = 0;
		private bool GameStarted = false;

		private long? TimeStamp = null;

		public int Clicks => _Clicks;
		public int Hits => _Hits;
		public double Accuracy => _Hits / (double)_Clicks;
		public List<long> TimesInTicks { get; } = new List<long>();

		private Target? TargetBounds { get; set; } = null;

		private class Target
		{
			public int X, Y;
			public int Width, Height;

			public Target(int x, int y)
			{
				X = x;
				Y = y;
				Width = TARGETSIZE;
				Height = TARGETSIZE;
			}

			public bool IsInTarget(int x1, int y1)
			{
				return Math.Sqrt(Math.Pow(x1 - (X + Width / 2), 2) + Math.Pow(y1 - (Y + Height / 2), 2)) <= TARGETSIZE / 2 + 1;
			}
		}

		public AimTest()
		{
			InitializeComponent();
		}

		private void WithInvoke(Control control, Action action)
		{
			if (InvokeRequired)
				control.Invoke(action);
			else
				action();
		}

		private void RecalculateScore(object? sender, EventArgs e)
		{
			if (_Clicks != 0)
				nudAccuracy.Value = (decimal)(_Hits / (double)_Clicks) * 100;
			else
				nudAccuracy.Value = 100;
		}

		private async void paGame_Click(object sender, EventArgs e)
		{
			await HandleClick((MouseEventArgs)e);
		}

		private async void paGame_DoubleClick(object sender, EventArgs e)
		{
			await HandleClick((MouseEventArgs)e);
		}

		private async Task HandleClick(MouseEventArgs e)
		{
			if (!GameStarted)
			{
				GameStarted = true;
				nudClicks.Value = _Clicks = 0;
				nudHits.Value = _Hits = 0;
				await PlaceNewTarget();
				return;
			}
			_Clicks++;
			WithInvoke(nudClicks, () => nudClicks.Value = _Clicks);
			if (TargetBounds == null || !TargetBounds.IsInTarget(e.X, e.Y))
				return;
			TargetBounds = null;
			WithInvoke(paGame, paGame.Invalidate);
			_Hits++;
			WithInvoke(nudHits, () => nudHits.Value = _Hits);
			await Task.Delay(SPAWNDELAY);
			await PlaceNewTarget();
		}

		private Task PlaceNewTarget()
		{
			return Task.Run(() =>
			{
				if (TimeStamp.HasValue)
				{
					TimesInTicks.Add(DateTime.Now.Ticks - TimeStamp.Value);
					WithInvoke(tbSpeed, () => tbSpeed.Text = $"{Convert.ToInt32(TimesInTicks.Average() / 10000)}ms");
				}
				Random r = new Random();
				int x = r.Next(0, paGame.Width - TARGETSIZE);
				int y = r.Next(0, paGame.Height - TARGETSIZE);
				TargetBounds = new Target(x, y);
				WithInvoke(paGame, paGame.Invalidate);
				WithInvoke(nudTargets, () => nudTargets.Value++);
				TimeStamp = DateTime.Now.Ticks;
			});
		}

		private void paGame_Paint(object sender, PaintEventArgs e)
		{
			if (!GameStarted)
			{
				TextRenderer.DrawText(e.Graphics, "Click to Start", paGame.Font, paGame.Bounds, paGame.ForeColor);
				return;
			}
			if (TargetBounds is not Target bounds)
				return;
			using Pen line = new Pen(Color.Black, 1);
			e.Graphics.DrawEllipse(line, new Rectangle(bounds.X, bounds.Y, bounds.Height, bounds.Width));
		}
	}
}
