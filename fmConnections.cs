using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Scue {
	public partial class fmConnections : Form {
		public fmConnections() {
			InitializeComponent();

			this.tvSavedConnections.MouseUp += tvSavedConnections_MouseUp;
			this.tvSavedConnections.MouseDoubleClick += tvSavedConnections_MouseDoubleClick;
		}

		private void fmConnections_Load(object sender, EventArgs e) {
			loadSavedConnections();
		}

		private void tvSavedConnections_MouseUp(object sender, MouseEventArgs e) {
			var node = this.tvSavedConnections.GetNodeAt(e.Location);

			if (node != null)
				this.tvSavedConnections.SelectedNode = node;

			this.miDelete.Enabled = this.tvSavedConnections.SelectedNode != null;
		}

		private void tvSavedConnections_MouseDoubleClick(object sender, MouseEventArgs e) {
			var node = this.tvSavedConnections.GetNodeAt(e.Location);

			if (node != null)
				this.tvSavedConnections.SelectedNode = node;

			var selectedNode = this.tvSavedConnections.SelectedNode as ConnectionTreeNode;

			if (selectedNode == null)
				return;

			this.tbHostname.Text = selectedNode.Hostname;
			this.tbUsername.Text = selectedNode.Username;
			this.tbPassword.Text = selectedNode.Password;

			btConnect_Click(null, null);
		}

		private void btSave_Click(object sender, EventArgs e) {
			if (string.IsNullOrWhiteSpace(this.tbHostname.Text) ||
			    string.IsNullOrWhiteSpace(this.tbUsername.Text)) {
				MessageBox.Show(
					"Both hostname and username as required!",
					"Save",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return;
			}

			var node = new ConnectionTreeNode(
				string.Format(
					"{0}@{1}",
					this.tbUsername.Text.Trim(),
					this.tbHostname.Text.Trim())) {
						Hostname = this.tbHostname.Text.Trim(),
						Username = this.tbUsername.Text.Trim(),
						Password = this.cbRememberPassword.Checked ? this.tbPassword.Text.Trim() : null
					};

			if (this.tvSavedConnections.SelectedNode == null)
				this.tvSavedConnections.Nodes.Add(node);
			else
				this.tvSavedConnections.SelectedNode.Nodes.Add(node);

			saveSavedConnections();
		}

		private void btConnect_Click(object sender, EventArgs e) {
			if (string.IsNullOrWhiteSpace(this.tbHostname.Text) ||
				string.IsNullOrWhiteSpace(this.tbUsername.Text)) {
				MessageBox.Show(
					"Both hostname and username as required!",
					"Save",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return;
			}

			var hostname = this.tbHostname.Text.Trim();
			var username = this.tbUsername.Text.Trim();
			var password = this.tbPassword.Text.Trim();

			if (string.IsNullOrWhiteSpace(password)) {
				var dialog = new fmConnectionPassword();

				if (dialog.ShowDialog(this) == DialogResult.Cancel)
					return;

				password = dialog.Password;
			}

			var connection = new SqlConnection {
				ConnectionString = string.Format(
					"Data Source={0}; User ID={1}; Password={2};",
					hostname,
					username,
					password)
			};

			try {
				connection.Open();
			}
			catch (Exception ex) {
				MessageBox.Show(
					ex.Message,
					"Connect",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return;
			}

			var queryWindow = new fmQueryWindow {
				Connection = connection
			};

			queryWindow.Show();

			this.WindowState = FormWindowState.Minimized;
		}

		private void btClose_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void miNewFolder_Click(object sender, EventArgs e) {
			var dialog = new fmNewFolder();

			if (dialog.ShowDialog(this) != DialogResult.OK)
				return;

			var node = new ConnectionTreeNode(dialog.FolderName);

			if (this.tvSavedConnections.SelectedNode == null)
				this.tvSavedConnections.Nodes.Add(node);
			else
				this.tvSavedConnections.SelectedNode.Nodes.Add(node);

			saveSavedConnections();
		}

		private void miDelete_Click(object sender, EventArgs e) {
			if (this.tvSavedConnections.SelectedNode == null)
				return;

			if (MessageBox.Show(
				"Are you sure?",
				"Delete",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question) == DialogResult.No)
				return;

			this.tvSavedConnections.Nodes.Remove(
				this.tvSavedConnections.SelectedNode);

			saveSavedConnections();
		}

		private void loadSavedConnections() {
			var file =
				string.Format(
					"{0}.SavedConnections.json",
					Application.ExecutablePath.Substring(
						Application.ExecutablePath.LastIndexOf(@"\", StringComparison.InvariantCultureIgnoreCase) + 1)
						.ToLower()
						.Replace(".exe", ""));

			var path = Path.Combine(
				Application.StartupPath,
				file);

			if (!File.Exists(path))
				return;

			this.tvSavedConnections.Nodes.Add(
				new ConnectionTreeNode {
					Text = "Connections"
				});

			var json = File.ReadAllText(path);
			var list = new JavaScriptSerializer().Deserialize<List<SavedTreeNode>>(json);

			loadSavedConnections(
				this.tvSavedConnections.Nodes[0] as ConnectionTreeNode,
				list);
		}

		private void loadSavedConnections(TreeNode node, IEnumerable<SavedTreeNode> list) {
			foreach (var item in list) {
				var ctn = new ConnectionTreeNode {
					Text = item.Name,
					Hostname = item.Hostname,
					Username = item.Username,
					Password = item.Password
				};

				loadSavedConnections(
					ctn,
					item.Children);

				node.Nodes.Add(
					ctn);

				node.Expand();
			}
		}

		private void saveSavedConnections() {
			var list = new List<SavedTreeNode>();

			foreach (ConnectionTreeNode node in this.tvSavedConnections.Nodes[0].Nodes) {
				var stn = new SavedTreeNode {
					Name = node.Text,
					Hostname = node.Hostname,
					Username = node.Username,
					Password = node.Password,
					Children = new List<SavedTreeNode>()
				};

				saveSavedConnections(
					stn,
					node);

				list.Add(
					stn);
			}

			var json = new JavaScriptSerializer().Serialize(list);
			var file =
				string.Format(
					"{0}.SavedConnections.json",
					Application.ExecutablePath.Substring(
						Application.ExecutablePath.LastIndexOf(@"\", StringComparison.InvariantCultureIgnoreCase) + 1)
						.ToLower()
						.Replace(".exe", ""));

			File.WriteAllText(
				Path.Combine(
					Application.StartupPath,
					file),
				json);
		}

		private void saveSavedConnections(SavedTreeNode stn, TreeNode selectedNode) {
			foreach (ConnectionTreeNode node in selectedNode.Nodes) {
				var temp = new SavedTreeNode {
					Name = node.Text,
					Hostname = node.Hostname,
					Username = node.Username,
					Password = node.Password,
					Children = new List<SavedTreeNode>()
				};

				saveSavedConnections(
					temp,
					node);

				stn.Children.Add(
					temp);
			}
		}
	}
}