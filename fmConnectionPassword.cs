using System;
using System.Windows.Forms;

namespace Scue {
	public partial class fmConnectionPassword : Form {
		public string Password { get; private set; }

		public fmConnectionPassword() {
			InitializeComponent();
		}

		private void btOk_Click(object sender, EventArgs e) {
			if (string.IsNullOrWhiteSpace(this.tbPassword.Text))
				this.DialogResult = DialogResult.Cancel;
			else
				this.Password = this.tbPassword.Text.Trim();
		}
	}
}
