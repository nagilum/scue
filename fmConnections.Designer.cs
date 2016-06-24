using System;
using System.Windows.Forms;

namespace Scue {
	partial class fmConnections {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.tvSavedConnections = new System.Windows.Forms.TreeView();
			this.cmSavedConnections = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.miNewFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.tbHostname = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbUsername = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cbRememberPassword = new System.Windows.Forms.CheckBox();
			this.btSave = new System.Windows.Forms.Button();
			this.btConnect = new System.Windows.Forms.Button();
			this.btClose = new System.Windows.Forms.Button();
			this.cmSavedConnections.SuspendLayout();
			this.SuspendLayout();
			// 
			// tvSavedConnections
			// 
			this.tvSavedConnections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.tvSavedConnections.ContextMenuStrip = this.cmSavedConnections;
			this.tvSavedConnections.FullRowSelect = true;
			this.tvSavedConnections.Location = new System.Drawing.Point(12, 12);
			this.tvSavedConnections.Name = "tvSavedConnections";
			this.tvSavedConnections.Size = new System.Drawing.Size(374, 569);
			this.tvSavedConnections.TabIndex = 0;
			// 
			// cmSavedConnections
			// 
			this.cmSavedConnections.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNewFolder,
            this.miDelete});
			this.cmSavedConnections.Name = "cmSavedConnections";
			this.cmSavedConnections.Size = new System.Drawing.Size(135, 48);
			// 
			// miNewFolder
			// 
			this.miNewFolder.Name = "miNewFolder";
			this.miNewFolder.Size = new System.Drawing.Size(134, 22);
			this.miNewFolder.Text = "New Folder";
			this.miNewFolder.Click += new System.EventHandler(this.miNewFolder_Click);
			// 
			// miDelete
			// 
			this.miDelete.Enabled = false;
			this.miDelete.Name = "miDelete";
			this.miDelete.Size = new System.Drawing.Size(134, 22);
			this.miDelete.Text = "Delete";
			this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
			// 
			// tbHostname
			// 
			this.tbHostname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbHostname.Location = new System.Drawing.Point(395, 28);
			this.tbHostname.Name = "tbHostname";
			this.tbHostname.Size = new System.Drawing.Size(493, 20);
			this.tbHostname.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(392, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Hostname:";
			// 
			// tbUsername
			// 
			this.tbUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbUsername.Location = new System.Drawing.Point(395, 72);
			this.tbUsername.Name = "tbUsername";
			this.tbUsername.Size = new System.Drawing.Size(493, 20);
			this.tbUsername.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(392, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Username:";
			// 
			// tbPassword
			// 
			this.tbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPassword.Location = new System.Drawing.Point(395, 116);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.PasswordChar = '•';
			this.tbPassword.Size = new System.Drawing.Size(493, 20);
			this.tbPassword.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(392, 100);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Password:";
			// 
			// cbRememberPassword
			// 
			this.cbRememberPassword.AutoSize = true;
			this.cbRememberPassword.Checked = true;
			this.cbRememberPassword.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbRememberPassword.Location = new System.Drawing.Point(395, 139);
			this.cbRememberPassword.Name = "cbRememberPassword";
			this.cbRememberPassword.Size = new System.Drawing.Size(126, 17);
			this.cbRememberPassword.TabIndex = 9;
			this.cbRememberPassword.Text = "Remember Password";
			this.cbRememberPassword.UseVisualStyleBackColor = true;
			// 
			// btSave
			// 
			this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btSave.Location = new System.Drawing.Point(624, 548);
			this.btSave.Name = "btSave";
			this.btSave.Size = new System.Drawing.Size(84, 33);
			this.btSave.TabIndex = 10;
			this.btSave.Text = "Save";
			this.btSave.UseVisualStyleBackColor = true;
			this.btSave.Click += new System.EventHandler(this.btSave_Click);
			// 
			// btConnect
			// 
			this.btConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btConnect.Location = new System.Drawing.Point(714, 548);
			this.btConnect.Name = "btConnect";
			this.btConnect.Size = new System.Drawing.Size(84, 33);
			this.btConnect.TabIndex = 11;
			this.btConnect.Text = "Connect";
			this.btConnect.UseVisualStyleBackColor = true;
			this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
			// 
			// btClose
			// 
			this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btClose.Location = new System.Drawing.Point(804, 548);
			this.btClose.Name = "btClose";
			this.btClose.Size = new System.Drawing.Size(84, 33);
			this.btClose.TabIndex = 12;
			this.btClose.Text = "Close";
			this.btClose.UseVisualStyleBackColor = true;
			this.btClose.Click += new System.EventHandler(this.btClose_Click);
			// 
			// fmConnections
			// 
			this.AcceptButton = this.btConnect;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(900, 593);
			this.Controls.Add(this.btClose);
			this.Controls.Add(this.btConnect);
			this.Controls.Add(this.btSave);
			this.Controls.Add(this.cbRememberPassword);
			this.Controls.Add(this.tbPassword);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbUsername);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbHostname);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tvSavedConnections);
			this.Name = "fmConnections";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Connections";
			this.Load += new System.EventHandler(this.fmConnections_Load);
			this.cmSavedConnections.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView tvSavedConnections;
		private System.Windows.Forms.TextBox tbHostname;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbUsername;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ContextMenuStrip cmSavedConnections;
		private System.Windows.Forms.ToolStripMenuItem miNewFolder;
		private System.Windows.Forms.ToolStripMenuItem miDelete;
		private System.Windows.Forms.CheckBox cbRememberPassword;
		private System.Windows.Forms.Button btSave;
		private System.Windows.Forms.Button btConnect;
		private System.Windows.Forms.Button btClose;
	}
}