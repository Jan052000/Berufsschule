using System.Diagnostics;

namespace HumanBenchmarks.Forms
{
	public partial class ReactionTest : Form
	{
		public const string GAMENAME = "Reaction";
		public const int GAMEID = 0;
		private bool WaitForStart { get; set; } = true;
		private bool ShowGreen { get; set; } = false;
		public List<int> Results { get; } = new List<int>();
		private System.Windows.Forms.Timer? Timer { get; set; }
		private Stopwatch? Stopwatch { get; set; }
		private bool TimerElapsed { get; set; } = false;
		private int? Result { get; set; }
		private bool FailStart { get; set; } = false;

		public ReactionTest()
		{
			InitializeComponent();
		}

		private void paGameArea_Paint(object sender, PaintEventArgs e)
		{
			Color backGround;
			if (ShowGreen)
				backGround = Color.LightGreen;
			else
				backGround = Color.LightBlue;
			using (Brush brush = new SolidBrush(backGround))
				e.Graphics.Clear(backGround);
			Control c = (sender as Control)!;
			if (WaitForStart)
			{
				string text;
				if (FailStart)
					text = "You clicked too soon,\n click again to start.";
				else
					text = $"Click here to start, wait for green and then click again.\n{(Result != null ? Result + "ms" : "")}";
				TextRenderer.DrawText(e.Graphics, text, c.Font, c.Bounds, c.ForeColor);
			}
		}

		private void paGameArea_Click(object sender, EventArgs e)
		{
			WaitForStart = false;
			FailStart = false;
			paGameArea.Invalidate();
			if (Timer is null && !TimerElapsed)
			{
				TimerElapsed = false;
				Timer = new System.Windows.Forms.Timer();
				Timer.Interval = new Random().Next(2000, 5500);
				Timer.Tick += Timer_Tick;
				Timer.Start();
			}
			else
			{
				Timer?.Stop();
				Timer = null;
				Stopwatch?.Stop();
				Result = (int?)Stopwatch?.ElapsedMilliseconds;
				Stopwatch = null;
				if (!TimerElapsed)
					FailStart = true;
				else if (Result.HasValue)
				{
					Results.Add(Result.Value);
					tbAvg.Text = $"{Math.Round(Results.Average(), 3)}ms";
				}
				WaitForStart = true;
				ShowGreen = false;
				TimerElapsed = false;
				paGameArea.Invalidate();
			}
		}

		private void Timer_Tick(object? sender, EventArgs e)
		{
			ShowGreen = true;
			TimerElapsed = true;
			if (Stopwatch is null)
			{
				Stopwatch = new Stopwatch();
				Stopwatch.Start();
			}
			else
			{
				Stopwatch.Stop();
			}
			(sender as System.Windows.Forms.Timer)?.Stop();
			Timer = null;
			paGameArea.Invalidate();
		}

		private void paGameArea_Resize(object sender, EventArgs e)
		{
			paGameArea.Invalidate();
		}
	}
}
