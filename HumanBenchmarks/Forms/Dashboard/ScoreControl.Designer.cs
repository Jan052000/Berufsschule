namespace HumanBenchmarks.Forms.Dashboard
{
	partial class ScoreControl
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
			paButtons = new Panel();
			paContent = new Panel();
			dgvContent = new DataGridView();
			paContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvContent).BeginInit();
			SuspendLayout();
			// 
			// paButtons
			// 
			paButtons.Dock = DockStyle.Bottom;
			paButtons.Location = new Point(0, 324);
			paButtons.Name = "paButtons";
			paButtons.Size = new Size(512, 65);
			paButtons.TabIndex = 0;
			// 
			// paContent
			// 
			paContent.Controls.Add(dgvContent);
			paContent.Dock = DockStyle.Fill;
			paContent.Location = new Point(0, 0);
			paContent.Name = "paContent";
			paContent.Size = new Size(512, 324);
			paContent.TabIndex = 1;
			// 
			// dgvContent
			// 
			dgvContent.AllowUserToAddRows = false;
			dgvContent.AllowUserToDeleteRows = false;
			dgvContent.AllowUserToResizeRows = false;
			dgvContent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvContent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvContent.Dock = DockStyle.Fill;
			dgvContent.Location = new Point(0, 0);
			dgvContent.Name = "dgvContent";
			dgvContent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvContent.Size = new Size(512, 324);
			dgvContent.TabIndex = 0;
			// 
			// ScoreControl
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(paContent);
			Controls.Add(paButtons);
			Name = "ScoreControl";
			Size = new Size(512, 389);
			paContent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvContent).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Panel paButtons;
		private Panel paContent;
		private DataGridView dgvContent;
	}
}
