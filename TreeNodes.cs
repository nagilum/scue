using System.Collections.Generic;
using System.Windows.Forms;

namespace Scue {
	public class ConnectionTreeNode : TreeNode {
		public string Hostname { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }

		public ConnectionTreeNode() {}

		public ConnectionTreeNode(string text) {
			this.Text = text;
		}
	}

	public class QueryWindowTreeNode : TreeNode {
		public QueryWindowTreeNode() {}

		public QueryWindowTreeNode(string text) {
			this.Text = text;
		}
	}

	public class QueryWindowDatabaseTreeNode : QueryWindowTreeNode {
		public NodeTypes NodeType { get; set; }

		public QueryWindowDatabaseTreeNode() {}

		public QueryWindowDatabaseTreeNode(string text) {
			this.Text = text;
		}
	}

	public class SavedTreeNode {
		public string Name { get; set; }
		public string Hostname { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }

		public List<SavedTreeNode> Children { get; set; }
	}

	public enum NodeTypes {
		Database,
		Folder,
		Table,
		Column,
		Dummy
	}
}