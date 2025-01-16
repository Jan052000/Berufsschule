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
			rtbInstructions = new RichTextBox();
			paGameArea = new GamePanel();
			SuspendLayout();
			// 
			// rtbInstructions
			// 
			rtbInstructions.BorderStyle = BorderStyle.FixedSingle;
			rtbInstructions.Dock = DockStyle.Bottom;
			rtbInstructions.Enabled = false;
			rtbInstructions.Location = new Point(0, 411);
			rtbInstructions.Name = "rtbInstructions";
			rtbInstructions.ReadOnly = true;
			rtbInstructions.Size = new Size(800, 39);
			rtbInstructions.TabIndex = 0;
			rtbInstructions.Text = "To start, click the blue area above.\nWhen the area turns green, click it to measure your reaction time";
			// 
			// paGameArea
			// 
			paGameArea.BackColor = SystemColors.ControlDark;
			paGameArea.Dock = DockStyle.Fill;
			paGameArea.Location = new Point(0, 0);
			paGameArea.Name = "paGameArea";
			paGameArea.Size = new Size(800, 411);
			paGameArea.TabIndex = 1;
			paGameArea.Click += paGameArea_Click;
			paGameArea.Paint += paGameArea_Paint;
			// 
			// ReactionTest
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(paGameArea);
			Controls.Add(rtbInstructions);
			Name = "ReactionTest";
			StartPosition = FormStartPosition.CenterParent;
			Text = "ReactionTest";
			ResumeLayout(false);
		}

		#endregion

		private RichTextBox rtbInstructions;
		private GamePanel paGameArea;
	}
}