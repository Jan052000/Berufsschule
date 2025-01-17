namespace HumanBenchmarks.Forms
{
	partial class AimTest
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
			nudAvgDistance = new NumericUpDown();
			laAvgDistance = new Label();
			tbSpeed = new TextBox();
			laSpeed = new Label();
			nudAccuracy = new NumericUpDown();
			laAccuracy = new Label();
			nudHits = new NumericUpDown();
			laHits = new Label();
			nudClicks = new NumericUpDown();
			laClicks = new Label();
			nudTargets = new NumericUpDown();
			laTargets = new Label();
			paGame = new GamePanel();
			paButtons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudAvgDistance).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudAccuracy).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudHits).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudClicks).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTargets).BeginInit();
			SuspendLayout();
			// 
			// paButtons
			// 
			paButtons.AutoScroll = true;
			paButtons.Controls.Add(nudAvgDistance);
			paButtons.Controls.Add(laAvgDistance);
			paButtons.Controls.Add(tbSpeed);
			paButtons.Controls.Add(laSpeed);
			paButtons.Controls.Add(nudAccuracy);
			paButtons.Controls.Add(laAccuracy);
			paButtons.Controls.Add(nudHits);
			paButtons.Controls.Add(laHits);
			paButtons.Controls.Add(nudClicks);
			paButtons.Controls.Add(laClicks);
			paButtons.Controls.Add(nudTargets);
			paButtons.Controls.Add(laTargets);
			paButtons.Dock = DockStyle.Bottom;
			paButtons.Location = new Point(0, 409);
			paButtons.Name = "paButtons";
			paButtons.Size = new Size(977, 41);
			paButtons.TabIndex = 0;
			// 
			// nudAvgDistance
			// 
			nudAvgDistance.Enabled = false;
			nudAvgDistance.Location = new Point(804, 6);
			nudAvgDistance.Name = "nudAvgDistance";
			nudAvgDistance.Size = new Size(120, 23);
			nudAvgDistance.TabIndex = 12;
			// 
			// laAvgDistance
			// 
			laAvgDistance.AutoSize = true;
			laAvgDistance.Location = new Point(722, 10);
			laAvgDistance.Name = "laAvgDistance";
			laAvgDistance.Size = new Size(76, 15);
			laAvgDistance.TabIndex = 11;
			laAvgDistance.Text = "Avg Distance";
			// 
			// tbSpeed
			// 
			tbSpeed.Enabled = false;
			tbSpeed.Location = new Point(616, 7);
			tbSpeed.Name = "tbSpeed";
			tbSpeed.ReadOnly = true;
			tbSpeed.Size = new Size(100, 23);
			tbSpeed.TabIndex = 10;
			tbSpeed.Text = "0ms";
			// 
			// laSpeed
			// 
			laSpeed.AutoSize = true;
			laSpeed.Location = new Point(547, 10);
			laSpeed.Name = "laSpeed";
			laSpeed.Size = new Size(63, 15);
			laSpeed.TabIndex = 9;
			laSpeed.Text = "Avg Speed";
			// 
			// nudAccuracy
			// 
			nudAccuracy.DecimalPlaces = 2;
			nudAccuracy.Enabled = false;
			nudAccuracy.Location = new Point(488, 6);
			nudAccuracy.Name = "nudAccuracy";
			nudAccuracy.Size = new Size(53, 23);
			nudAccuracy.TabIndex = 8;
			nudAccuracy.Value = new decimal(new int[] { 100, 0, 0, 0 });
			// 
			// laAccuracy
			// 
			laAccuracy.AutoSize = true;
			laAccuracy.Location = new Point(426, 10);
			laAccuracy.Name = "laAccuracy";
			laAccuracy.Size = new Size(56, 15);
			laAccuracy.TabIndex = 7;
			laAccuracy.Text = "Accuracy";
			// 
			// nudHits
			// 
			nudHits.Enabled = false;
			nudHits.Location = new Point(324, 6);
			nudHits.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
			nudHits.Name = "nudHits";
			nudHits.Size = new Size(96, 23);
			nudHits.TabIndex = 6;
			nudHits.ValueChanged += RecalculateScore;
			// 
			// laHits
			// 
			laHits.AutoSize = true;
			laHits.Location = new Point(290, 10);
			laHits.Name = "laHits";
			laHits.Size = new Size(28, 15);
			laHits.TabIndex = 5;
			laHits.Text = "Hits";
			// 
			// nudClicks
			// 
			nudClicks.Enabled = false;
			nudClicks.Location = new Point(188, 6);
			nudClicks.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
			nudClicks.Name = "nudClicks";
			nudClicks.Size = new Size(96, 23);
			nudClicks.TabIndex = 4;
			nudClicks.ValueChanged += RecalculateScore;
			// 
			// laClicks
			// 
			laClicks.AutoSize = true;
			laClicks.Location = new Point(144, 10);
			laClicks.Name = "laClicks";
			laClicks.Size = new Size(38, 15);
			laClicks.TabIndex = 3;
			laClicks.Text = "Clicks";
			// 
			// nudTargets
			// 
			nudTargets.Enabled = false;
			nudTargets.Location = new Point(57, 6);
			nudTargets.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
			nudTargets.Name = "nudTargets";
			nudTargets.Size = new Size(81, 23);
			nudTargets.TabIndex = 2;
			// 
			// laTargets
			// 
			laTargets.AutoSize = true;
			laTargets.Location = new Point(7, 10);
			laTargets.Name = "laTargets";
			laTargets.Size = new Size(44, 15);
			laTargets.TabIndex = 1;
			laTargets.Text = "Targets";
			// 
			// paGame
			// 
			paGame.BackColor = SystemColors.ControlDark;
			paGame.Dock = DockStyle.Fill;
			paGame.Location = new Point(0, 0);
			paGame.Name = "paGame";
			paGame.Size = new Size(977, 409);
			paGame.TabIndex = 1;
			paGame.Click += paGame_Click;
			paGame.Paint += paGame_Paint;
			paGame.DoubleClick += paGame_DoubleClick;
			// 
			// AimTest
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(977, 450);
			Controls.Add(paGame);
			Controls.Add(paButtons);
			Name = "AimTest";
			StartPosition = FormStartPosition.CenterParent;
			Text = "AimTest";
			paButtons.ResumeLayout(false);
			paButtons.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudAvgDistance).EndInit();
			((System.ComponentModel.ISupportInitialize)nudAccuracy).EndInit();
			((System.ComponentModel.ISupportInitialize)nudHits).EndInit();
			((System.ComponentModel.ISupportInitialize)nudClicks).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTargets).EndInit();
			ResumeLayout(false);
		}

		#endregion
		private Panel paButtons;
		private GamePanel paGame;
		private NumericUpDown nudTargets;
		private Label laTargets;
		private Label laClicks;
		private NumericUpDown nudHits;
		private Label laHits;
		private NumericUpDown nudClicks;
		private NumericUpDown nudAccuracy;
		private Label laAccuracy;
		private TextBox tbSpeed;
		private Label laSpeed;
		private NumericUpDown nudAvgDistance;
		private Label laAvgDistance;
	}
}