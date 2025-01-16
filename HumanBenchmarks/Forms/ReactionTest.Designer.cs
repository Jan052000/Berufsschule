namespace HumanBenchmarks.Forms
{
	partial class ReactionTest
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			paGameArea = new GamePanel();
			panel1 = new Panel();
			tbAvg = new TextBox();
			laAvg = new Label();
			rtbInstructions = new RichTextBox();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// paGameArea
			// 
			paGameArea.BackColor = SystemColors.ControlDark;
			paGameArea.Dock = DockStyle.Fill;
			paGameArea.Location = new Point(0, 0);
			paGameArea.Name = "paGameArea";
			paGameArea.Size = new Size(800, 450);
			paGameArea.TabIndex = 1;
			paGameArea.Click += paGameArea_Click;
			paGameArea.Paint += paGameArea_Paint;
			// 
			// panel1
			// 
			panel1.Controls.Add(tbAvg);
			panel1.Controls.Add(laAvg);
			panel1.Controls.Add(rtbInstructions);
			panel1.Dock = DockStyle.Bottom;
			panel1.Location = new Point(0, 411);
			panel1.Name = "panel1";
			panel1.Size = new Size(800, 39);
			panel1.TabIndex = 0;
			// 
			// tbAvg
			// 
			tbAvg.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			tbAvg.Enabled = false;
			tbAvg.Location = new Point(655, 13);
			tbAvg.Name = "tbAvg";
			tbAvg.Size = new Size(133, 23);
			tbAvg.TabIndex = 3;
			tbAvg.Text = "0ms";
			// 
			// laAvg
			// 
			laAvg.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			laAvg.AutoSize = true;
			laAvg.Location = new Point(599, 16);
			laAvg.Name = "laAvg";
			laAvg.Size = new Size(50, 15);
			laAvg.TabIndex = 2;
			laAvg.Text = "Average";
			// 
			// rtbInstructions
			// 
			rtbInstructions.BorderStyle = BorderStyle.FixedSingle;
			rtbInstructions.Enabled = false;
			rtbInstructions.Location = new Point(0, -1);
			rtbInstructions.Name = "rtbInstructions";
			rtbInstructions.ReadOnly = true;
			rtbInstructions.Size = new Size(358, 39);
			rtbInstructions.TabIndex = 1;
			rtbInstructions.Text = "To start, click the blue area above.\nWhen the area turns green, click it to measure your reaction time";
			// 
			// ReactionTest
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(panel1);
			Controls.Add(paGameArea);
			Name = "ReactionTest";
			StartPosition = FormStartPosition.CenterParent;
			Text = "ReactionTest";
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion
		private GamePanel paGameArea;
		private Panel panel1;
		private TextBox tbAvg;
		private Label laAvg;
		private RichTextBox rtbInstructions;
	}
}