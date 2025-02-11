namespace Liegeplatzverwaltung.RequestBooking
{
	partial class RequestControl
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
			laTitle = new Label();
			laMail = new Label();
			tbMail = new TextBox();
			laType = new Label();
			tbType = new TextBox();
			laDepth = new Label();
			laWidth = new Label();
			laLength = new Label();
			laIMO = new Label();
			nudDepth = new NumericUpDown();
			nudWidth = new NumericUpDown();
			nudLength = new NumericUpDown();
			tbIMO = new TextBox();
			cbLiegeplatzOptions = new ComboBox();
			laAssign = new Label();
			((System.ComponentModel.ISupportInitialize)nudDepth).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudWidth).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudLength).BeginInit();
			SuspendLayout();
			// 
			// laTitle
			// 
			laTitle.AutoSize = true;
			laTitle.Location = new Point(3, 0);
			laTitle.Name = "laTitle";
			laTitle.Size = new Size(77, 15);
			laTitle.TabIndex = 0;
			laTitle.Text = "{Placeholder}";
			// 
			// laMail
			// 
			laMail.AutoSize = true;
			laMail.Location = new Point(3, 34);
			laMail.Name = "laMail";
			laMail.Size = new Size(30, 15);
			laMail.TabIndex = 1;
			laMail.Text = "Mail";
			// 
			// tbMail
			// 
			tbMail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbMail.Location = new Point(65, 31);
			tbMail.Name = "tbMail";
			tbMail.ReadOnly = true;
			tbMail.Size = new Size(272, 23);
			tbMail.TabIndex = 2;
			// 
			// laType
			// 
			laType.AutoSize = true;
			laType.Location = new Point(3, 63);
			laType.Name = "laType";
			laType.Size = new Size(25, 15);
			laType.TabIndex = 3;
			laType.Text = "Typ";
			// 
			// tbType
			// 
			tbType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbType.Location = new Point(65, 60);
			tbType.Name = "tbType";
			tbType.ReadOnly = true;
			tbType.Size = new Size(272, 23);
			tbType.TabIndex = 4;
			// 
			// laDepth
			// 
			laDepth.AutoSize = true;
			laDepth.Location = new Point(3, 92);
			laDepth.Name = "laDepth";
			laDepth.Size = new Size(39, 15);
			laDepth.TabIndex = 5;
			laDepth.Text = "Depth";
			// 
			// laWidth
			// 
			laWidth.AutoSize = true;
			laWidth.Location = new Point(3, 120);
			laWidth.Name = "laWidth";
			laWidth.Size = new Size(39, 15);
			laWidth.TabIndex = 7;
			laWidth.Text = "Width";
			// 
			// laLength
			// 
			laLength.AutoSize = true;
			laLength.Location = new Point(3, 149);
			laLength.Name = "laLength";
			laLength.Size = new Size(43, 15);
			laLength.TabIndex = 8;
			laLength.Text = "Height";
			// 
			// laIMO
			// 
			laIMO.AutoSize = true;
			laIMO.Location = new Point(3, 179);
			laIMO.Name = "laIMO";
			laIMO.Size = new Size(56, 15);
			laIMO.TabIndex = 9;
			laIMO.Text = "Ship IMO";
			// 
			// nudDepth
			// 
			nudDepth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			nudDepth.Enabled = false;
			nudDepth.Location = new Point(65, 89);
			nudDepth.Name = "nudDepth";
			nudDepth.ReadOnly = true;
			nudDepth.Size = new Size(272, 23);
			nudDepth.TabIndex = 10;
			// 
			// nudWidth
			// 
			nudWidth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			nudWidth.Enabled = false;
			nudWidth.Location = new Point(65, 118);
			nudWidth.Name = "nudWidth";
			nudWidth.ReadOnly = true;
			nudWidth.Size = new Size(272, 23);
			nudWidth.TabIndex = 11;
			// 
			// nudLength
			// 
			nudLength.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			nudLength.Enabled = false;
			nudLength.Location = new Point(65, 147);
			nudLength.Name = "nudLength";
			nudLength.ReadOnly = true;
			nudLength.Size = new Size(272, 23);
			nudLength.TabIndex = 12;
			// 
			// tbIMO
			// 
			tbIMO.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbIMO.Location = new Point(65, 176);
			tbIMO.Name = "tbIMO";
			tbIMO.ReadOnly = true;
			tbIMO.Size = new Size(272, 23);
			tbIMO.TabIndex = 13;
			// 
			// cbLiegeplatzOptions
			// 
			cbLiegeplatzOptions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			cbLiegeplatzOptions.DropDownStyle = ComboBoxStyle.DropDownList;
			cbLiegeplatzOptions.FormattingEnabled = true;
			cbLiegeplatzOptions.Location = new Point(65, 205);
			cbLiegeplatzOptions.Name = "cbLiegeplatzOptions";
			cbLiegeplatzOptions.Size = new Size(272, 23);
			cbLiegeplatzOptions.TabIndex = 14;
			cbLiegeplatzOptions.DropDown += cbLiegeplatzOptions_DropDown;
			cbLiegeplatzOptions.SelectedValueChanged += cbLiegeplatzOptions_SelectedValueChanged;
			// 
			// laAssign
			// 
			laAssign.AutoSize = true;
			laAssign.Location = new Point(3, 208);
			laAssign.Name = "laAssign";
			laAssign.Size = new Size(42, 15);
			laAssign.TabIndex = 15;
			laAssign.Text = "Assign";
			// 
			// RequestControl
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(laAssign);
			Controls.Add(cbLiegeplatzOptions);
			Controls.Add(tbIMO);
			Controls.Add(nudLength);
			Controls.Add(nudWidth);
			Controls.Add(nudDepth);
			Controls.Add(laIMO);
			Controls.Add(laLength);
			Controls.Add(laWidth);
			Controls.Add(laDepth);
			Controls.Add(tbType);
			Controls.Add(laType);
			Controls.Add(tbMail);
			Controls.Add(laMail);
			Controls.Add(laTitle);
			Name = "RequestControl";
			Size = new Size(340, 231);
			((System.ComponentModel.ISupportInitialize)nudDepth).EndInit();
			((System.ComponentModel.ISupportInitialize)nudWidth).EndInit();
			((System.ComponentModel.ISupportInitialize)nudLength).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label laTitle;
		private Label laMail;
		private TextBox tbMail;
		private Label laType;
		private TextBox tbType;
		private Label laDepth;
		private Label laWidth;
		private Label laLength;
		private Label laIMO;
		private NumericUpDown nudDepth;
		private NumericUpDown nudWidth;
		private NumericUpDown nudLength;
		private TextBox tbIMO;
		private ComboBox cbLiegeplatzOptions;
		private Label laAssign;
	}
}
