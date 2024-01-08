using kvi;
using Oex;

namespace si {
	public partial class MainForm :Form {
		OedForm oed;

		public MainForm() {
			InitializeComponent();
			oed = new OedForm();

			oex.ExpandEvent.FileOpenHandler += openOed;
		}

		private void MainForm_Load(object sender, EventArgs e) {
		}

		private void MainForm_Shown(object sender, EventArgs e){
			oex.FocusPanel();
			oex.PaintSelectedItem();
		}

		private void openOed(string _path){
			if(oed.IsDisposed){
				oed = new OedForm();
				if(oed.OpenFIle(_path)){
					oed.Show();
				}
			}
			else{
				if(oed.OpenFIle(_path)){
					oed.Show();
				}
			}
		}
	}
}