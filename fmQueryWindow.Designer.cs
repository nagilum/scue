namespace Scue {
	partial class fmQueryWindow {
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
			this.scTreeView = new System.Windows.Forms.SplitContainer();
			this.tvDatabases = new System.Windows.Forms.TreeView();
			this.tcQueries = new System.Windows.Forms.TabControl();
			((System.ComponentModel.ISupportInitialize)(this.scTreeView)).BeginInit();
			this.scTreeView.Panel1.SuspendLayout();
			this.scTreeView.Panel2.SuspendLayout();
			this.scTreeView.SuspendLayout();
			this.SuspendLayout();
			// 
			// scTreeView
			// 
			this.scTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scTreeView.Location = new System.Drawing.Point(0, 0);
			this.scTreeView.Name = "scTreeView";
			// 
			// scTreeView.Panel1
			// 
			this.scTreeView.Panel1.Controls.Add(this.tvDatabases);
			// 
			// scTreeView.Panel2
			// 
			this.scTreeView.Panel2.Controls.Add(this.tcQueries);
			this.scTreeView.Size = new System.Drawing.Size(1584, 961);
			this.scTreeView.SplitterDistance = 406;
			this.scTreeView.TabIndex = 0;
			// 
			// tvDatabases
			// 
			this.tvDatabases.Location = new System.Drawing.Point(42, 52);
			this.tvDatabases.Name = "tvDatabases";
			this.tvDatabases.Size = new System.Drawing.Size(268, 382);
			this.tvDatabases.TabIndex = 0;
			// 
			// tcQueries
			// 
			this.tcQueries.Location = new System.Drawing.Point(69, 31);
			this.tcQueries.Name = "tcQueries";
			this.tcQueries.SelectedIndex = 0;
			this.tcQueries.Size = new System.Drawing.Size(979, 697);
			this.tcQueries.TabIndex = 0;
			// 
			// fmQueryWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1584, 961);
			this.Controls.Add(this.scTreeView);
			this.Name = "fmQueryWindow";
			this.Text = "QueryWindow";
			this.Load += new System.EventHandler(this.fmQueryWindow_Load);
			this.scTreeView.Panel1.ResumeLayout(false);
			this.scTreeView.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.scTreeView)).EndInit();
			this.scTreeView.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer scTreeView;
		private System.Windows.Forms.TreeView tvDatabases;
		private System.Windows.Forms.TabControl tcQueries;
	}
}