using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scue {
	public class AppSettings {
		public class ConnectionsWindow {
			public static FormWindowState WindowState { get; set; }
			public static int WindowLeft { get; set; }
			public static int WindowTop { get; set; }
			public static int WindowWidth { get; set; }
			public static int WindowHeight { get; set; }
		}

		public static void Load() {
		}

		public static void Save() {
		}
	}
}