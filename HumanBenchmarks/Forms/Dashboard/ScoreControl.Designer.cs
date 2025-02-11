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
			paAvgs = new Panel();
			laAvgs = new Label();
			flpAvgs = new FlowLayoutPanel();
			paButtons.SuspendLayout();
			paContent.SuspendLayout();
			paDataGrid.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvContent).BeginInit();
			paTitle.SuspendLayout();
			paAvgs.SuspendLayout();
			SuspendLayout();
			// 
			// paButtons
			// 
			paButtons.Controls.Add(flpAvgs);
			paButtons.Controls.Add(paAvgs);
			paButtons.Dock = DockStyle.Bottom;
			paButtons.Location = new Point(0, 469);
			paButtons.Name = "paButtons";
			paButtons.Size = new Size(554, 92);
			paButtons.TabIndex = 0;
			// 
			// paContent
			// 
			paContent.Controls.Add(paDataGrid);
			paContent.Controls.Add(paTitle);
			paContent.Dock = DockStyle.Fill;
			paContent.Location = new Point(0, 0);
			paContent.Name = "paContent";
			paContent.Size = new Size(554, 469);
			paContent.TabIndex = 1;
			// 
			// paDataGrid
			// 
			paDataGrid.Controls.Add(dgvContent);
			paDataGrid.Dock = DockStyle.Fill;
			paDataGrid.Location = new Point(0, 21);
			paDataGrid.Name = "paDataGrid";
			paDataGrid.Size = new Size(554, 448);
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
			dgvContent.Size = new Size(554, 448);
			dgvContent.TabIndex = 0;
			// 
			// paTitle
			// 
			paTitle.Controls.Add(laTitle);
			paTitle.Dock = DockStyle.Top;
			paTitle.Location = new Point(0, 0);
			paTitle.Name = "paTitle";
			paTitle.Size = new Size(554, 21);
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
			// paAvgs
			// 
			paAvgs.Controls.Add(laAvgs);
			paAvgs.Dock = DockStyle.Top;
			paAvgs.Location = new Point(0, 0);
			paAvgs.Name = "paAvgs";
			paAvgs.Size = new Size(554, 22);
			paAvgs.TabIndex = 0;
			// 
			// laAvgs
			// 
			laAvgs.AutoSize = true;
			laAvgs.Location = new Point(3, 3);
			laAvgs.Name = "laAvgs";
			laAvgs.Size = new Size(33, 15);
			laAvgs.TabIndex = 0;
			laAvgs.Text = "Avgs";
			// 
			// flpAvgs
			// 
			flpAvgs.Dock = DockStyle.Fill;
			flpAvgs.Location = new Point(0, 22);
			flpAvgs.Name = "flpAvgs";
			flpAvgs.Size = new Size(554, 70);
			flpAvgs.TabIndex = 1;
			// 
			// ScoreControl
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(paContent);
			Controls.Add(paButtons);
			Name = "ScoreControl";
			Size = new Size(554, 561);
			paButtons.ResumeLayout(false);
			paContent.ResumeLayout(false);
			paDataGrid.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvContent).EndInit();
			paTitle.ResumeLayout(false);
			paTitle.PerformLayout();
			paAvgs.ResumeLayout(false);
			paAvgs.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Panel paButtons;
		private Panel paContent;
		private Panel paTitle;
		private Label laTitle;
		private Panel paDataGrid;
		private DataGridView dgvContent;
		private Panel paAvgs;
		private Label laAvgs;
		private FlowLayoutPanel flpAvgs;
	}
}
