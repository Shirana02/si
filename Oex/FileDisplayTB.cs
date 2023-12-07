using kvi;

namespace Oex {
	public class FileDisplayTB :KviTextBox {
		internal FileItemType Type { get; private set;}

		public FileDisplayTB(String _name):base() {
			//Text = "hogaaaa";
			//Multiline = false;
			//Height = Font.Height + 2;
			//BorderStyle = BorderStyle.None;
			//ExpandEvent.OverEscapeHandler += ExpandEvent_OverEscapeHandler;
			//GotFocus += Ktb_GotFocusHandler;
		}

		private void Ktb_GotFocusHandler(object? sender, EventArgs e) {
			Parent.Select();
		}

		private void ExpandEvent_OverEscapeHandler() {
			Parent.Select();
		}
	}
}
