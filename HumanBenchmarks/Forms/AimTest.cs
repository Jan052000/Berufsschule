using System.Diagnostics;

namespace HumanBenchmarks.Forms
{
	internal partial class AimTest : Form
	{
		public const string GAMENAME = "Aim";
		public const int GAMEID = 2;
		private const int TARGETSIZE = 25;
		private const int TARGETRINGSPACING = 15;
		private const int SPAWNDELAY = 100;

		private int _Clicks = 0;
		private int _Hits = 0;
		private bool GameStarted = false;

		public int Clicks => _Clicks;
		public int Hits => _Hits;
		public double Accuracy => _Hits / (double)_Clicks;
		public List<long> TimesInTicks { get; } = new List<long>();
		public List<double> HitAccuracies { get; } = new List<double>();

		private Target? TargetBounds { get; set; } = null;
		private Stopwatch? StopWatch { get; set; }

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
				return DistanceFromCenterPX(x1, y1) <= TARGETSIZE / 2 + 1;
			}

			public double DistanceFromCenterPX(int x, int y)
			{
				return Math.Sqrt(Math.Pow(x - (X + Width / 2), 2) + Math.Pow(y - (Y + Height / 2), 2));
			}
		}

		public AimTest()
		{
			InitializeComponent();
			MinimumSize = new Size(150 + TARGETSIZE + 2, 150 + paButtons.Height + TARGETSIZE + 2);
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
			HitAccuracies.Add(TargetBounds.DistanceFromCenterPX(e.X, e.Y));
			WithInvoke(nudAvgDistance, () => nudAvgDistance.Value = (decimal)HitAccuracies.Average());
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
				if (StopWatch != null)
				{
					StopWatch.Stop();
					TimesInTicks.Add(StopWatch.ElapsedTicks);
					WithInvoke(tbSpeed, () => tbSpeed.Text = $"{Math.Round(TimesInTicks.Average() / 10000)}ms");
				}
				Random r = new Random();
				int x = r.Next(0, paGame.Width - TARGETSIZE);
				int y = r.Next(0, paGame.Height - TARGETSIZE);
				TargetBounds = new Target(x, y);
				WithInvoke(paGame, paGame.Invalidate);
				WithInvoke(nudTargets, () => nudTargets.Value++);
				StopWatch = Stopwatch.StartNew();
			});
		}

		private void paGame_Paint(object sender, PaintEventArgs e)
		{
			if (!GameStarted)
			{
				TextRenderer.DrawText(e.Graphics, "Click to Start", paGame.Font, paGame.Bounds, paGame.ForeColor);
				return;
			}
			if (TargetBounds == null)
				return;

			using Pen line = new Pen(Color.Black, 1);

			for (int i = 0; i < TARGETSIZE; i += TARGETRINGSPACING)
			{
				int x1 = TargetBounds.X + i / 2;
				int y1 = TargetBounds.Y + i / 2;

				e.Graphics.DrawEllipse(line, x1, y1, TARGETSIZE - i, TARGETSIZE - i);
			}
			e.Graphics.DrawLine(line, TargetBounds.X + TargetBounds.Width / 2, TargetBounds.Y, TargetBounds.X + TargetBounds.Width / 2, TargetBounds.Y + TargetBounds.Height);
			e.Graphics.DrawLine(line, TargetBounds.X, TargetBounds.Y + TargetBounds.Height / 2, TargetBounds.X + TargetBounds.Width, TargetBounds.Y + TargetBounds.Height / 2);
		}
	}
}
