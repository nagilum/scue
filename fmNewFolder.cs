using System;
using System.Windows.Forms;

namespace Scue {
	public partial class fmNewFolder : Form {
		public string FolderName { get; private set; }

		public fmNewFolder() {
			InitializeComponent();
		}

		private void btOk_Click(object sender, EventArgs e) {
			if (string.IsNullOrWhiteSpace(this.tbName.Text))
				this.DialogResult = DialogResult.Cancel;
			else
				this.FolderName = this.tbName.Text.Trim();
		}
	}
}