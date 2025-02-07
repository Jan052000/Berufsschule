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
			paContent = new Panel();
			paAimTest = new Panel();
			splitter2 = new Splitter();
			paSimonSays = new Panel();
			splitter1 = new Splitter();
			paReactionTime = new Panel();
			paContent.SuspendLayout();
			SuspendLayout();
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
			paContent.Size = new Size(784, 411);
			paContent.TabIndex = 0;
			// 
			// paAimTest
			// 
			paAimTest.BackColor = SystemColors.ControlLight;
			paAimTest.Dock = DockStyle.Fill;
			paAimTest.Location = new Point(526, 0);
			paAimTest.Name = "paAimTest";
			paAimTest.Size = new Size(258, 411);
			paAimTest.TabIndex = 9;
			// 
			// splitter2
			// 
			splitter2.Location = new Point(523, 0);
			splitter2.Name = "splitter2";
			splitter2.Size = new Size(3, 411);
			splitter2.TabIndex = 8;
			splitter2.TabStop = false;
			// 
			// paSimonSays
			// 
			paSimonSays.BackColor = SystemColors.ControlLight;
			paSimonSays.Dock = DockStyle.Left;
			paSimonSays.Location = new Point(245, 0);
			paSimonSays.Name = "paSimonSays";
			paSimonSays.Size = new Size(278, 411);
			paSimonSays.TabIndex = 7;
			// 
			// splitter1
			// 
			splitter1.Location = new Point(242, 0);
			splitter1.Name = "splitter1";
			splitter1.Size = new Size(3, 411);
			splitter1.TabIndex = 6;
			splitter1.TabStop = false;
			// 
			// paReactionTime
			// 
			paReactionTime.BackColor = SystemColors.ControlLight;
			paReactionTime.Dock = DockStyle.Left;
			paReactionTime.Location = new Point(0, 0);
			paReactionTime.Name = "paReactionTime";
			paReactionTime.Size = new Size(242, 411);
			paReactionTime.TabIndex = 5;
			// 
			// DashboardForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(784, 411);
			Controls.Add(paContent);
			MinimumSize = new Size(300, 100);
			Name = "DashboardForm";
			Text = "Dashboard";
			paContent.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private Panel paContent;
		private Panel paAimTest;
		private Splitter splitter2;
		private Panel paSimonSays;
		private Splitter splitter1;
		private Panel paReactionTime;
	}
}