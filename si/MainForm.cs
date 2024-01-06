using kvi;
using Oex;

namespace si {
	public partial class MainForm :Form {
		public MainForm() {
			InitializeComponent();
			//siAppSet = new SiAppSet(this.ClientSize, new Point(0, 0));
			//this.Controls.Add(siAppSet);
		}


		//private SiAppSet siAppSet;
		private void MainForm_Load(object sender, EventArgs e) {
		}

		private void MainForm_ResizeEnd(object sender, EventArgs e) {
			//siAppSet.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);
		}

		private void MainForm_Shown(object sender, EventArgs e){
			oex.FocusPanel();
			oex.PaintSelectedItem();
		}
	}
}