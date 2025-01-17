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
			btClose = new Button();
			btReactionCheck = new Button();
			btSimonSays = new Button();
			btAimTest = new Button();
			SuspendLayout();
			// 
			// btClose
			// 
			btClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btClose.Location = new Point(849, 415);
			btClose.Name = "btClose";
			btClose.Size = new Size(75, 23);
			btClose.TabIndex = 0;
			btClose.Text = "Close";
			btClose.UseVisualStyleBackColor = true;
			btClose.Click += btClose_Click;
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
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(936, 450);
			Controls.Add(btAimTest);
			Controls.Add(btSimonSays);
			Controls.Add(btReactionCheck);
			Controls.Add(btClose);
			Name = "MainForm";
			Text = "MainForm";
			ResumeLayout(false);
		}

		#endregion

		private Button btClose;
		private Button btReactionCheck;
		private Button btSimonSays;
		private Button btAimTest;
	}
}