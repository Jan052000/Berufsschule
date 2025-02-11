namespace HumanBenchmarks.Forms
{
	partial class SimonSaysGame
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
			paBottom = new Panel();
			laRound = new Label();
			btRegenField = new Button();
			nudSize = new NumericUpDown();
			btStart = new Button();
			nudRound = new NumericUpDown();
			tlpGame = new TestTableLayoutPanel();
			paBottom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudSize).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudRound).BeginInit();
			SuspendLayout();
			// 
			// paBottom
			// 
			paBottom.Controls.Add(laRound);
			paBottom.Controls.Add(btRegenField);
			paBottom.Controls.Add(nudSize);
			paBottom.Controls.Add(btStart);
			paBottom.Controls.Add(nudRound);
			paBottom.Dock = DockStyle.Bottom;
			paBottom.Location = new Point(0, 393);
			paBottom.Name = "paBottom";
			paBottom.Size = new Size(936, 57);
			paBottom.TabIndex = 0;
			// 
			// laRound
			// 
			laRound.AutoSize = true;
			laRound.Location = new Point(12, 26);
			laRound.Name = "laRound";
			laRound.Size = new Size(42, 15);
			laRound.TabIndex = 4;
			laRound.Text = "Round";
			// 
			// btRegenField
			// 
			btRegenField.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btRegenField.Location = new Point(642, 22);
			btRegenField.Name = "btRegenField";
			btRegenField.Size = new Size(75, 23);
			btRegenField.TabIndex = 3;
			btRegenField.Text = "Regen";
			btRegenField.UseVisualStyleBackColor = true;
			btRegenField.Click += btRegenField_Click;
			// 
			// nudSize
			// 
			nudSize.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			nudSize.Location = new Point(723, 22);
			nudSize.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
			nudSize.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
			nudSize.Name = "nudSize";
			nudSize.Size = new Size(120, 23);
			nudSize.TabIndex = 2;
			nudSize.Value = new decimal(new int[] { 3, 0, 0, 0 });
			// 
			// btStart
			// 
			btStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btStart.Location = new Point(849, 22);
			btStart.Name = "btStart";
			btStart.Size = new Size(75, 23);
			btStart.TabIndex = 1;
			btStart.Text = "Start";
			btStart.UseVisualStyleBackColor = true;
			btStart.Click += StartGame;
			// 
			// nudRound
			// 
			nudRound.Enabled = false;
			nudRound.Location = new Point(60, 22);
			nudRound.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			nudRound.Name = "nudRound";
			nudRound.ReadOnly = true;
			nudRound.Size = new Size(49, 23);
			nudRound.TabIndex = 0;
			// 
			// tlpGame
			// 
			tlpGame.ColumnCount = 2;
			tlpGame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tlpGame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tlpGame.Dock = DockStyle.Fill;
			tlpGame.Location = new Point(0, 0);
			tlpGame.Name = "tlpGame";
			tlpGame.RowCount = 2;
			tlpGame.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tlpGame.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tlpGame.Size = new Size(936, 393);
			tlpGame.TabIndex = 1;
			// 
			// SimonSaysGame
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(936, 450);
			Controls.Add(tlpGame);
			Controls.Add(paBottom);
			Name = "SimonSaysGame";
			StartPosition = FormStartPosition.CenterParent;
			Text = "SimonSays";
			paBottom.ResumeLayout(false);
			paBottom.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudSize).EndInit();
			((System.ComponentModel.ISupportInitialize)nudRound).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Panel paBottom;
		private TestTableLayoutPanel tlpGame;
		private NumericUpDown nudRound;
		private Button btStart;
		private NumericUpDown nudSize;
		private Button btRegenField;
		private Label laRound;
	}
}