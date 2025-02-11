namespace HumanBenchmarks.Forms.Dashboard
{
	internal partial class StatControl : UserControl
	{
		private string MetricName { get; }
		private string Value { get; }

		public StatControl(string metricName, string value)
		{
			InitializeComponent();
			MetricName = metricName;
			Value = value;
			int titleWidth = TextRenderer.MeasureText(MetricName, paTitle.Font).Width;
			int valueWidth = TextRenderer.MeasureText(Value, paAvg.Font).Width;
			paTitle.Width = titleWidth + 5;
			Width = paTitle.Width + valueWidth + 10;
		}

		private void paTitle_Paint(object sender, PaintEventArgs e)
		{
			Panel? p = sender as Panel;
			e.Graphics.Clear(p!.BackColor);
			Rectangle bounds = new Rectangle(0, 0, p.Width, p.Height);
			TextRenderer.DrawText(e.Graphics, MetricName, p!.Font, bounds, p!.ForeColor);
		}

		private void paAvg_Paint(object sender, PaintEventArgs e)
		{
			Panel? p = sender as Panel;
			e.Graphics.Clear(p!.BackColor);
			Rectangle bounds = new Rectangle(0, 0, p.Width, p.Height);
			TextRenderer.DrawText(e.Graphics, Value, p!.Font, bounds, p!.ForeColor);
		}
	}
}
