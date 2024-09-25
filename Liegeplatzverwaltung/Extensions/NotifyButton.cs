namespace Liegeplatzverwaltung.Extensions
{
	internal class NotifyButton : Button
	{
		private int messageCount { get; set; }
		public int MessageCount
		{
			get => messageCount;
			set
			{
				if (messageCount != value)
				{
					messageCount = value;
					Invalidate();
				}
			}
		}

		protected override void OnPaint(PaintEventArgs pevent)
		{
			base.OnPaint(pevent);

			int circleWidth = 15;
			if (Width < 2 * circleWidth || Height < circleWidth)
				return;

			using SolidBrush red = new SolidBrush(Color.Red);
			Rectangle bounds = pevent.ClipRectangle;
			Rectangle circleBounds = new Rectangle(bounds.Width - circleWidth - 2, 1, circleWidth, circleWidth);

			pevent.Graphics.FillEllipse(red, circleBounds);
			TextRenderer.DrawText(pevent.Graphics, MessageCount.ToString(), new Font(Font.FontFamily, 9), circleBounds, ForeColor);
		}
	}
}
