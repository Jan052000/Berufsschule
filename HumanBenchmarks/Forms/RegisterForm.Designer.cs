namespace HumanBenchmarks.Forms
{
	partial class RegisterForm
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
			btRegister = new Button();
			tbFirstName = new TextBox();
			laFirstName = new Label();
			laLastName = new Label();
			laBirthday = new Label();
			tbLastName = new TextBox();
			dtpBirthday = new DateTimePicker();
			nudID = new NumericUpDown();
			laID = new Label();
			((System.ComponentModel.ISupportInitialize)nudID).BeginInit();
			SuspendLayout();
			// 
			// btRegister
			// 
			btRegister.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btRegister.Location = new Point(363, 134);
			btRegister.Name = "btRegister";
			btRegister.Size = new Size(75, 23);
			btRegister.TabIndex = 0;
			btRegister.Text = "Register";
			btRegister.UseVisualStyleBackColor = true;
			btRegister.Click += btRegister_Click;
			// 
			// tbFirstName
			// 
			tbFirstName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbFirstName.Location = new Point(83, 18);
			tbFirstName.Name = "tbFirstName";
			tbFirstName.Size = new Size(355, 23);
			tbFirstName.TabIndex = 1;
			// 
			// laFirstName
			// 
			laFirstName.AutoSize = true;
			laFirstName.Location = new Point(12, 21);
			laFirstName.Name = "laFirstName";
			laFirstName.Size = new Size(54, 15);
			laFirstName.TabIndex = 2;
			laFirstName.Text = "Vorname";
			// 
			// laLastName
			// 
			laLastName.AutoSize = true;
			laLastName.Location = new Point(12, 50);
			laLastName.Name = "laLastName";
			laLastName.Size = new Size(65, 15);
			laLastName.TabIndex = 3;
			laLastName.Text = "Nachname";
			// 
			// laBirthday
			// 
			laBirthday.AutoSize = true;
			laBirthday.Location = new Point(12, 82);
			laBirthday.Name = "laBirthday";
			laBirthday.Size = new Size(65, 15);
			laBirthday.TabIndex = 4;
			laBirthday.Text = "Geburtstag";
			// 
			// tbLastName
			// 
			tbLastName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbLastName.Location = new Point(83, 47);
			tbLastName.Name = "tbLastName";
			tbLastName.Size = new Size(355, 23);
			tbLastName.TabIndex = 5;
			// 
			// dtpBirthday
			// 
			dtpBirthday.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			dtpBirthday.Location = new Point(83, 76);
			dtpBirthday.Name = "dtpBirthday";
			dtpBirthday.Size = new Size(355, 23);
			dtpBirthday.TabIndex = 6;
			// 
			// nudID
			// 
			nudID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			nudID.Enabled = false;
			nudID.Location = new Point(83, 105);
			nudID.Name = "nudID";
			nudID.ReadOnly = true;
			nudID.Size = new Size(355, 23);
			nudID.TabIndex = 7;
			// 
			// laID
			// 
			laID.AutoSize = true;
			laID.Location = new Point(60, 107);
			laID.Name = "laID";
			laID.Size = new Size(17, 15);
			laID.TabIndex = 8;
			laID.Text = "Id";
			// 
			// RegisterForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(450, 169);
			Controls.Add(laID);
			Controls.Add(nudID);
			Controls.Add(dtpBirthday);
			Controls.Add(tbLastName);
			Controls.Add(laBirthday);
			Controls.Add(laLastName);
			Controls.Add(laFirstName);
			Controls.Add(tbFirstName);
			Controls.Add(btRegister);
			MaximumSize = new Size(466, 208);
			Name = "RegisterForm";
			Text = "RegisterForm";
			((System.ComponentModel.ISupportInitialize)nudID).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btRegister;
		private TextBox tbFirstName;
		private Label laFirstName;
		private Label laLastName;
		private Label laBirthday;
		private TextBox tbLastName;
		private DateTimePicker dtpBirthday;
		private NumericUpDown nudID;
		private Label laID;
	}
}