namespace HumanBenchmarks.Forms.Dashboard
{
	partial class DashboardForm
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
			paButtons = new Panel();
			laEnd = new Label();
			dtpEnd = new DateTimePicker();
			laStart = new Label();
			dtpStart = new DateTimePicker();
			paContent = new Panel();
			paAimTest = new Panel();
			splitter2 = new Splitter();
			paSimonSays = new Panel();
			splitter1 = new Splitter();
			paReactionTime = new Panel();
			paButtons.SuspendLayout();
			paContent.SuspendLayout();
			SuspendLayout();
			// 
			// paButtons
			// 
			paButtons.Controls.Add(laEnd);
			paButtons.Controls.Add(dtpEnd);
			paButtons.Controls.Add(laStart);
			paButtons.Controls.Add(dtpStart);
			paButtons.Dock = DockStyle.Bottom;
			paButtons.Location = new Point(0, 359);
			paButtons.Name = "paButtons";
			paButtons.Size = new Size(784, 52);
			paButtons.TabIndex = 0;
			// 
			// laEnd
			// 
			laEnd.AutoSize = true;
			laEnd.Location = new Point(348, 19);
			laEnd.Name = "laEnd";
			laEnd.Size = new Size(66, 15);
			laEnd.TabIndex = 3;
			laEnd.Text = "End Datum";
			// 
			// dtpEnd
			// 
			dtpEnd.Location = new Point(420, 13);
			dtpEnd.Name = "dtpEnd";
			dtpEnd.Size = new Size(200, 23);
			dtpEnd.TabIndex = 2;
			// 
			// laStart
			// 
			laStart.AutoSize = true;
			laStart.Location = new Point(68, 19);
			laStart.Name = "laStart";
			laStart.Size = new Size(70, 15);
			laStart.TabIndex = 1;
			laStart.Text = "Start Datum";
			// 
			// dtpStart
			// 
			dtpStart.Location = new Point(144, 13);
			dtpStart.Name = "dtpStart";
			dtpStart.Size = new Size(200, 23);
			dtpStart.TabIndex = 0;
			// 
			// paContent
			// 
			paContent.Controls.Add(paAimTest);
			paContent.Controls.Add(splitter2);
			paContent.Controls.Add(paSimonSays);
			paContent.Controls.Add(splitter1);
			paContent.Controls.Add(paReactionTime);
			paContent.Dock = DockStyle.Fill;
			paContent.Location = new Point(0, 0);
			paContent.Name = "paContent";
			paContent.Size = new Size(784, 359);
			paContent.TabIndex = 1;
			// 
			// paAimTest
			// 
			paAimTest.BackColor = SystemColors.ControlLight;
			paAimTest.Dock = DockStyle.Fill;
			paAimTest.Location = new Point(526, 0);
			paAimTest.Name = "paAimTest";
			paAimTest.Size = new Size(258, 359);
			paAimTest.TabIndex = 9;
			// 
			// splitter2
			// 
			splitter2.Location = new Point(523, 0);
			splitter2.Name = "splitter2";
			splitter2.Size = new Size(3, 359);
			splitter2.TabIndex = 8;
			splitter2.TabStop = false;
			// 
			// paSimonSays
			// 
			paSimonSays.BackColor = SystemColors.ControlLight;
			paSimonSays.Dock = DockStyle.Left;
			paSimonSays.Location = new Point(245, 0);
			paSimonSays.Name = "paSimonSays";
			paSimonSays.Size = new Size(278, 359);
			paSimonSays.TabIndex = 7;
			// 
			// splitter1
			// 
			splitter1.Location = new Point(242, 0);
			splitter1.Name = "splitter1";
			splitter1.Size = new Size(3, 359);
			splitter1.TabIndex = 6;
			splitter1.TabStop = false;
			// 
			// paReactionTime
			// 
			paReactionTime.BackColor = SystemColors.ControlLight;
			paReactionTime.Dock = DockStyle.Left;
			paReactionTime.Location = new Point(0, 0);
			paReactionTime.Name = "paReactionTime";
			paReactionTime.Size = new Size(242, 359);
			paReactionTime.TabIndex = 5;
			// 
			// DashboardForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(784, 411);
			Controls.Add(paContent);
			Controls.Add(paButtons);
			MinimumSize = new Size(300, 100);
			Name = "DashboardForm";
			Text = "Dashboard";
			paButtons.ResumeLayout(false);
			paButtons.PerformLayout();
			paContent.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private Panel paButtons;
		private Panel paContent;
		private Panel paAimTest;
		private Splitter splitter2;
		private Panel paSimonSays;
		private Splitter splitter1;
		private Panel paReactionTime;
		private Label laEnd;
		private DateTimePicker dtpEnd;
		private Label laStart;
		private DateTimePicker dtpStart;
	}
}