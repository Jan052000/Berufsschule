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
			paDataGrid = new Panel();
			dgvContent = new DataGridView();
			paTitle = new Panel();
			laTitle = new Label();
			paContent.SuspendLayout();
			paDataGrid.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvContent).BeginInit();
			paTitle.SuspendLayout();
			SuspendLayout();
			// 
			// paButtons
			// 
			paButtons.Dock = DockStyle.Bottom;
			paButtons.Location = new Point(0, 333);
			paButtons.Name = "paButtons";
			paButtons.Size = new Size(512, 56);
			paButtons.TabIndex = 0;
			// 
			// paContent
			// 
			paContent.Controls.Add(paDataGrid);
			paContent.Controls.Add(paTitle);
			paContent.Dock = DockStyle.Fill;
			paContent.Location = new Point(0, 0);
			paContent.Name = "paContent";
			paContent.Size = new Size(512, 333);
			paContent.TabIndex = 1;
			// 
			// paDataGrid
			// 
			paDataGrid.Controls.Add(dgvContent);
			paDataGrid.Dock = DockStyle.Fill;
			paDataGrid.Location = new Point(0, 21);
			paDataGrid.Name = "paDataGrid";
			paDataGrid.Size = new Size(512, 312);
			paDataGrid.TabIndex = 1;
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
			dgvContent.Size = new Size(512, 312);
			dgvContent.TabIndex = 0;
			// 
			// paTitle
			// 
			paTitle.Controls.Add(laTitle);
			paTitle.Dock = DockStyle.Top;
			paTitle.Location = new Point(0, 0);
			paTitle.Name = "paTitle";
			paTitle.Size = new Size(512, 21);
			paTitle.TabIndex = 0;
			// 
			// laTitle
			// 
			laTitle.AutoSize = true;
			laTitle.Location = new Point(0, 0);
			laTitle.Name = "laTitle";
			laTitle.Size = new Size(53, 15);
			laTitle.TabIndex = 0;
			laTitle.Text = "{{game}}";
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
			paDataGrid.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvContent).EndInit();
			paTitle.ResumeLayout(false);
			paTitle.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Panel paButtons;
		private Panel paContent;
		private Panel paTitle;
		private Label laTitle;
		private Panel paDataGrid;
		private DataGridView dgvContent;
	}
}
