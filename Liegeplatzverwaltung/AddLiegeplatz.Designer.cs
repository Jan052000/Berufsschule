namespace Liegeplatzverwaltung
{
	partial class AddLiegeplatz
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
			btCancel = new Button();
			btAdd = new Button();
			paControls = new Panel();
			SuspendLayout();
			// 
			// btCancel
			// 
			btCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btCancel.Location = new Point(428, 402);
			btCancel.Name = "btCancel";
			btCancel.Size = new Size(75, 23);
			btCancel.TabIndex = 0;
			btCancel.Text = "Cancel";
			btCancel.UseVisualStyleBackColor = true;
			btCancel.Click += btCancel_Click;
			// 
			// btAdd
			// 
			btAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btAdd.Location = new Point(347, 402);
			btAdd.Name = "btAdd";
			btAdd.Size = new Size(75, 23);
			btAdd.TabIndex = 1;
			btAdd.Text = "Add";
			btAdd.UseVisualStyleBackColor = true;
			btAdd.Click += btAdd_Click;
			// 
			// paControls
			// 
			paControls.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			paControls.Location = new Point(12, 12);
			paControls.Name = "paControls";
			paControls.Size = new Size(491, 384);
			paControls.TabIndex = 2;
			// 
			// AddLiegeplatz
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(515, 437);
			Controls.Add(paControls);
			Controls.Add(btAdd);
			Controls.Add(btCancel);
			Name = "AddLiegeplatz";
			Text = "AddLiegeplatz";
			ResumeLayout(false);
		}

		#endregion

		private Button btCancel;
		private Button btAdd;
		private Panel paControls;
	}
}