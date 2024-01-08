namespace si {
	public partial class OedForm :Form {
		public OedForm() {
			InitializeComponent();

			oed.ExpandEvent.FileCloseHandler += this.Close;
		}

		public bool OpenFIle(string _path){
			if(!System.IO.File.Exists(_path))
				return false;

			oed.OpenFile(_path);
			return true;
		}
	}
}
