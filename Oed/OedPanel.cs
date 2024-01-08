namespace Oed {
	public partial class OedPanel :UserControl {
		public OedEvent ExpandEvent{ get; set; }
		private OedControler controler;
		public string? FilePath{ get; private set; }

		public OedPanel() {
			InitializeComponent();

			controler = new OedControler();
			ExpandEvent = new OedEvent();

			ktb_textArea.ExpandEvent.PressColonHandler += selectCommandArea;

			ktb_commandArea.ExpandEvent.PressColonHandler += selectTextKtb;
			ktb_commandArea.ExpandEvent.PressEnterHandler += recieveCommand;

			GotFocus += gotFocusHandler;
		}

		//Method
		public bool OpenFile(string _path){
			if(!System.IO.File.Exists(_path))
				return false;

			FilePath = _path;
			using(StreamReader sr = new StreamReader(_path)){
				ktb_textArea.Text = sr.ReadToEnd();
			}
				return true;
		}
		//Method---

		//イベントハンドラ
		private void gotFocusHandler(object? sender, EventArgs e){
			ktb_textArea.Select();
		}
		private void selectCommandArea(){
			ktb_commandArea.Select();
			SendKeys.Send("i");
		}
		private void selectTextKtb(){
			ktb_commandArea.Clear();
			ktb_textArea.Select();
		}
		private void recieveCommand(){
			controler.command.RecieveCommand(this);
		}
		//イベントハンドラーーー
	}
}
