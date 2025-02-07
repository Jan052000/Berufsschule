namespace HumanBenchmarks.Forms.Dashboard
{
	partial class StatControl
	{
		/// <summary> 
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Komponenten-Designer generierter Code

		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			paTitle = new Panel();
			paAvg = new Panel();
			SuspendLayout();
			// 
			// paTitle
			// 
			paTitle.Dock = DockStyle.Left;
			paTitle.Location = new Point(0, 0);
			paTitle.Name = "paTitle";
			paTitle.Size = new Size(66, 23);
			paTitle.TabIndex = 0;
			paTitle.Paint += paTitle_Paint;
			// 
			// paAvg
			// 
			paAvg.Dock = DockStyle.Fill;
			paAvg.Location = new Point(66, 0);
			paAvg.Name = "paAvg";
			paAvg.Size = new Size(158, 23);
			paAvg.TabIndex = 1;
			paAvg.Paint += paAvg_Paint;
			// 
			// StatControl
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BorderStyle = BorderStyle.FixedSingle;
			Controls.Add(paAvg);
			Controls.Add(paTitle);
			Name = "StatControl";
			Size = new Size(224, 23);
			ResumeLayout(false);
		}

		#endregion

		private Panel paTitle;
		private Panel paAvg;
	}
}
