namespace Liegeplatzverwaltung
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			btAddNew = new Button();
			btRemoveSelected = new Button();
			dataGridView1 = new DataGridView();
			btRequests = new Extensions.NotifyButton();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// btAddNew
			// 
			btAddNew.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btAddNew.Location = new Point(713, 12);
			btAddNew.Name = "btAddNew";
			btAddNew.Size = new Size(75, 30);
			btAddNew.TabIndex = 0;
			btAddNew.Text = "+";
			btAddNew.UseVisualStyleBackColor = true;
			btAddNew.Click += btAddNew_Click;
			// 
			// btRemoveSelected
			// 
			btRemoveSelected.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btRemoveSelected.Location = new Point(713, 48);
			btRemoveSelected.Name = "btRemoveSelected";
			btRemoveSelected.Size = new Size(75, 30);
			btRemoveSelected.TabIndex = 1;
			btRemoveSelected.Text = "-";
			btRemoveSelected.UseVisualStyleBackColor = true;
			btRemoveSelected.Click += btRemoveSelected_Click;
			// 
			// dataGridView1
			// 
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
			dataGridView1.Location = new Point(0, 0);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.Size = new Size(707, 450);
			dataGridView1.TabIndex = 3;
			// 
			// btRequests
			// 
			btRequests.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btRequests.Font = new Font("Segoe UI", 12F);
			btRequests.Location = new Point(713, 408);
			btRequests.Name = "btRequests";
			btRequests.Size = new Size(75, 30);
			btRequests.TabIndex = 4;
			btRequests.Text = "✉";
			btRequests.UseVisualStyleBackColor = true;
			btRequests.Click += btRequests_Click;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(btRequests);
			Controls.Add(dataGridView1);
			Controls.Add(btRemoveSelected);
			Controls.Add(btAddNew);
			Name = "MainForm";
			Text = "Liegeplatzverwaltung";
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Button btAddNew;
		private Button btRemoveSelected;
		private DataGridView dataGridView1;
		private Extensions.NotifyButton btRequests;
	}
}
