namespace HumanBenchmarks.Forms
{
	partial class MainForm
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
			btReactionCheck = new Button();
			btSimonSays = new Button();
			btAimTest = new Button();
			btDashboard = new Button();
			btLogout = new Button();
			SuspendLayout();
			// 
			// btReactionCheck
			// 
			btReactionCheck.Location = new Point(12, 12);
			btReactionCheck.Name = "btReactionCheck";
			btReactionCheck.Size = new Size(123, 23);
			btReactionCheck.TabIndex = 1;
			btReactionCheck.Text = "Reaction Test";
			btReactionCheck.UseVisualStyleBackColor = true;
			btReactionCheck.Click += btReactionCheck_Click;
			// 
			// btSimonSays
			// 
			btSimonSays.Location = new Point(12, 41);
			btSimonSays.Name = "btSimonSays";
			btSimonSays.Size = new Size(123, 23);
			btSimonSays.TabIndex = 2;
			btSimonSays.Text = "Simon Says";
			btSimonSays.UseVisualStyleBackColor = true;
			btSimonSays.Click += btSimonSays_Click;
			// 
			// btAimTest
			// 
			btAimTest.Location = new Point(12, 70);
			btAimTest.Name = "btAimTest";
			btAimTest.Size = new Size(123, 23);
			btAimTest.TabIndex = 3;
			btAimTest.Text = "Aim Test";
			btAimTest.UseVisualStyleBackColor = true;
			btAimTest.Click += btAimTest_Click;
			// 
			// btDashboard
			// 
			btDashboard.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btDashboard.Location = new Point(815, 12);
			btDashboard.Name = "btDashboard";
			btDashboard.Size = new Size(109, 23);
			btDashboard.TabIndex = 4;
			btDashboard.Text = "Dashboard";
			btDashboard.UseVisualStyleBackColor = true;
			btDashboard.Click += btDashboard_Click;
			// 
			// btLogout
			// 
			btLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btLogout.Location = new Point(815, 415);
			btLogout.Name = "btLogout";
			btLogout.Size = new Size(109, 23);
			btLogout.TabIndex = 5;
			btLogout.Text = "Abmelden";
			btLogout.UseVisualStyleBackColor = true;
			btLogout.Click += btLogout_Click;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(936, 450);
			Controls.Add(btLogout);
			Controls.Add(btDashboard);
			Controls.Add(btAimTest);
			Controls.Add(btSimonSays);
			Controls.Add(btReactionCheck);
			Name = "MainForm";
			Text = "MainForm";
			ResumeLayout(false);
		}

		#endregion
		private Button btReactionCheck;
		private Button btSimonSays;
		private Button btAimTest;
		private Button btDashboard;
		private Button btLogout;
	}
}