namespace HumanBenchmarks.Forms
{
	partial class LoginForm
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
			components = new System.ComponentModel.Container();
			btLogin = new Button();
			btRegister = new Button();
			laID = new Label();
			nudID = new NumericUpDown();
			toolTip1 = new ToolTip(components);
			((System.ComponentModel.ISupportInitialize)nudID).BeginInit();
			SuspendLayout();
			// 
			// btLogin
			// 
			btLogin.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btLogin.Location = new Point(355, 41);
			btLogin.Name = "btLogin";
			btLogin.Size = new Size(75, 23);
			btLogin.TabIndex = 0;
			btLogin.Text = "Login";
			btLogin.UseVisualStyleBackColor = true;
			btLogin.Click += btLogin_Click;
			// 
			// btRegister
			// 
			btRegister.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btRegister.Location = new Point(268, 41);
			btRegister.Name = "btRegister";
			btRegister.Size = new Size(81, 23);
			btRegister.TabIndex = 1;
			btRegister.Text = "Registrieren";
			btRegister.UseVisualStyleBackColor = true;
			btRegister.Click += btRegister_Click;
			// 
			// laID
			// 
			laID.AutoSize = true;
			laID.Location = new Point(12, 14);
			laID.Name = "laID";
			laID.Size = new Size(18, 15);
			laID.TabIndex = 2;
			laID.Text = "ID";
			// 
			// nudID
			// 
			nudID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			nudID.Location = new Point(36, 12);
			nudID.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			nudID.Name = "nudID";
			nudID.Size = new Size(394, 23);
			nudID.TabIndex = 3;
			nudID.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// LoginForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(442, 76);
			Controls.Add(nudID);
			Controls.Add(laID);
			Controls.Add(btRegister);
			Controls.Add(btLogin);
			Name = "LoginForm";
			Text = "LoginForm";
			((System.ComponentModel.ISupportInitialize)nudID).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btLogin;
		private Button btRegister;
		private Label laID;
		private NumericUpDown nudID;
		private ToolTip toolTip1;
	}
}