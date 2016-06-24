using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scue {
	public partial class fmQueryWindow : Form {
		public SqlConnection Connection { get; set; }

		public fmQueryWindow() {
			InitializeComponent();

			this.tvDatabases.Dock = DockStyle.Fill;
			this.tcQueries.Dock = DockStyle.Fill;

			this.tvDatabases.BeforeExpand += this.tvDatabases_BeforeExpand;
		}

		private void fmQueryWindow_Load(object sender, EventArgs e) {
			this.loadDatabases();
		}

		private void tvDatabases_BeforeExpand(object sender, TreeViewCancelEventArgs e) {
			if (e.Node == null ||
				e.Node.Nodes.Count <= 0 ||
				e.Node.Nodes[0].Text != "(dummy)")
				return;

			var node = e.Node as QueryWindowDatabaseTreeNode;

			if (node == null)
				return;

			e.Node.Nodes.Clear();

			switch (node.NodeType) {
				case NodeTypes.Database:
					loadTables(node);
					break;

				case NodeTypes.Table:
					loadColumns(node);
					break;
			}

			e.Node.Expand();
		}

		private void loadDatabases() {
			var reservedTableNames = new[] {
				"master",
				"tempdb",
				"model",
				"msdb"
			};

			this.tvDatabases.Nodes.Clear();
			this.tvDatabases.Nodes.Add(new QueryWindowTreeNode("Databases"));

			using (var dataAdapter = new SqlDataAdapter("SELECT name FROM master.dbo.sysdatabases ORDER BY name ASC;", this.Connection)) {
				var dataSet = new DataSet();
				dataAdapter.Fill(dataSet);

				if (dataSet.Tables.Count == 0)
					return;

				foreach (DataRow row in dataSet.Tables[0].Rows) {
					if (row["name"] == null)
						continue;

					var databaseName = row["name"].ToString();

					if (reservedTableNames.Contains(databaseName))
						continue;

					var dbnode = new QueryWindowDatabaseTreeNode(databaseName) {
						NodeType = NodeTypes.Database
					};

					var dummy = new QueryWindowDatabaseTreeNode("(dummy)") {
						NodeType = NodeTypes.Dummy
					};

					dbnode.Nodes.Add(dummy);
					this.tvDatabases.Nodes[0].Nodes.Add(dbnode);
				}
			}

			this.tvDatabases.Nodes[0].Expand();
		}

		private void loadTables(TreeNode selectedNode) {
			var query = string.Format(
				"USE {0}; SELECT TABLE_SCHEMA + '.' + TABLE_NAME AS tableName FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' ORDER BY tableName ASC;",
				selectedNode.Text);

			var flnode = new QueryWindowDatabaseTreeNode("Tables") {
				NodeType = NodeTypes.Folder
			};

			selectedNode.Nodes.Add(
				flnode);

			using (var dataAdapter = new SqlDataAdapter(query, this.Connection)) {
				var dataSet = new DataSet();
				dataAdapter.Fill(dataSet);

				if (dataSet.Tables.Count == 0)
					return;

				foreach (DataRow row in dataSet.Tables[0].Rows) {
					if (row["tableName"] == null)
						continue;

					var tableName = row["tableName"].ToString();

					var tbnode = new QueryWindowDatabaseTreeNode(tableName) {
						NodeType = NodeTypes.Table
					};

					var dummy = new QueryWindowDatabaseTreeNode("(dummy)") {
						NodeType = NodeTypes.Dummy
					};

					tbnode.Nodes.Add(dummy);
					flnode.Nodes.Add(tbnode);
				}
			}
		}

		private void loadColumns(TreeNode selectedNode) {
			var tableSchema = selectedNode.Text.Substring(0, selectedNode.Text.IndexOf('.'));
			var tableName = selectedNode.Text.Substring(selectedNode.Text.IndexOf('.') + 1);
			var query = string.Format(
				"SELECT COLUMN_NAME,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH,IS_NULLABLE,NUMERIC_PRECISION,NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '{0}' AND TABLE_NAME = '{1}' ORDER BY ORDINAL_POSITION ASC;",
				tableSchema,
				tableName);

			var pkeys = getPrimaryKeys(tableSchema, tableName);
			var fkeys = new List<string>();

			var flnode = new QueryWindowDatabaseTreeNode("Columns") {
				NodeType = NodeTypes.Folder
			};

			selectedNode.Nodes.Add(
				flnode);

			using (var dataAdapter = new SqlDataAdapter(query, this.Connection)) {
				var dataSet = new DataSet();
				dataAdapter.Fill(dataSet);

				if (dataSet.Tables.Count == 0)
					return;

				foreach (DataRow row in dataSet.Tables[0].Rows) {
					if (row["COLUMN_NAME"] == null)
						continue;

					var columnName = row["COLUMN_NAME"].ToString();
					var dataType = row["DATA_TYPE"].ToString();
					var dataLength = row["CHARACTER_MAXIMUM_LENGTH"] != null ? row["CHARACTER_MAXIMUM_LENGTH"].ToString() : null;
					var isNull = row["IS_NULLABLE"].ToString().ToLower() == "yes";
					var isPK = pkeys.Contains(columnName);
					var isFK = fkeys.Contains(columnName);

					if (dataLength == "-1")
						dataLength = "max";

					if (dataLength == null &&
					    row["NUMERIC_PRECISION"] != null &&
						row["NUMERIC_SCALE"] != null)
						dataLength = string.Format(
							"{0},{1}",
							row["NUMERIC_PRECISION"],
							row["NUMERIC_SCALE"]);

					var columnTitle =
						string.Format(
							"{0} ({1}{2}{3}{4}, {5})",
							columnName,
							isPK ? "PK, " : "",
							isFK ? "FK, " : "",
							dataType,
							!string.IsNullOrWhiteSpace(dataLength) ? "(" + dataLength + ")" : "",
							isNull ? "null" : "not null");

					var clnode = new QueryWindowDatabaseTreeNode(columnTitle) {
						NodeType = NodeTypes.Column
					};

					flnode.Nodes.Add(clnode);
				}
			}
		}

		private List<string> getPrimaryKeys(string tableSchema, string tableName) {
			var pkeys = new List<string>();
			var query = string.Format(
				"SELECT ccu.COLUMN_NAME,i.is_primary_key FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ccu LEFT OUTER JOIN sys.indexes i ON ccu.CONSTRAINT_NAME = i.name WHERE ccu.TABLE_SCHEMA = '{0}' AND ccu.TABLE_NAME = '{1}';",
				tableSchema,
				tableName);

			using (var dataAdapter = new SqlDataAdapter(query, this.Connection)) {
				var dataSet = new DataSet();
				dataAdapter.Fill(dataSet);

				if (dataSet.Tables.Count == 0)
					return new List<string>();

				foreach (DataRow row in dataSet.Tables[0].Rows) {
					if (row["is_primary_key"] == null ||
						row["COLUMN_NAME"] == null ||
						row["is_primary_key"].ToString().ToLower() != "true")
						continue;

					pkeys.Add(row["COLUMN_NAME"].ToString());
				}
			}

			return pkeys;
		} 
	}
}