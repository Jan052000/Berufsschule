using System.ComponentModel;

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

		private Color messageCircleColor { get; set; } = Color.Red;
		[DefaultValue(typeof(Color), "Red")]
		public Color MessageCircleColor
		{
			get => messageCircleColor;
			set
			{
				if (messageCircleColor != value)
				{
					messageCircleColor = value;
					Invalidate();
				}
			}
		}

		private Color messageCountColor { get; set; } = Color.Black;
		[DefaultValue(typeof(Color), "Black")]
		public Color MessageCountColor
		{
			get => messageCountColor;
			set
			{
				if (messageCountColor != value)
				{
					messageCountColor = value;
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

			using SolidBrush red = new SolidBrush(MessageCircleColor);
			Rectangle bounds = pevent.ClipRectangle;
			Rectangle circleBounds = new Rectangle(bounds.Width - circleWidth - 2, 1, circleWidth, circleWidth);

			if (MessageCount == 0)
				return;

			pevent.Graphics.FillEllipse(red, circleBounds);
			TextRenderer.DrawText(pevent.Graphics, MessageCount.ToString(), new Font(Font.FontFamily, 9), circleBounds, ForeColor);
		}
	}
}
