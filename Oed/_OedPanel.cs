using kvi;

namespace Oed {
	public class _OedPanel :Control {
		public OedEvent ExpandEvent{ get; set; }
		private OedControler controler;

		internal RichTextBox filePath;
		internal KviTextBox _textKbt;
		internal KviTextBox _commandKtb;

		public _OedPanel(Size _size, Point _location){
			controler = new OedControler();
			ExpandEvent = new OedEvent();

			filePath = new RichTextBox();
			filePath.Multiline = false;
			filePath.ReadOnly = true;

			_textKbt = new KviTextBox();
			_textKbt.ExpandEvent.PressColonHandler += selectCommandKtb;

			_commandKtb = new KviTextBox();
			_commandKtb.Multiline = false;
			_commandKtb.ExpandEvent.PressColonHandler += selectTextKtb;
			_commandKtb.ExpandEvent.PressEnterHandler += recieveCommand;

			SetSize(_size);
			SetLocation(_location);

			this.Controls.Add(filePath);
			this.Controls.Add(_textKbt);
			this.Controls.Add(_commandKtb);

			GotFocus += gotFocusHandler;
		}

		protected override void OnKeyDown(KeyEventArgs e){
			base.OnKeyDown(e);
			//controler.RecieveKey(e.KeyData, this);
		}

		//フォーム内表示調整ロジック
		public bool SetLocation(Point _location){
			Location = _location;
			filePath.Location = _location;
			_textKbt.Location = new Point(_location.X, _location.Y + filePath.Height);
			_commandKtb.Location = new Point(_location.X, _textKbt.Location.Y + _textKbt.Height);
			return true;
		}

		public bool SetSize(Size _size){
			Size = _size;
			filePath.Size = new Size(_size.Width, filePath.Font.Height + 2);
			_commandKtb.Width = _size.Width;
			_commandKtb.Height = _commandKtb.Font.Height + 2;
			_textKbt.Width = _size.Width;
			_textKbt.Height = _size.Height - filePath.Height - _commandKtb.Height;
			return true;
		}
		//フォーム内表示調整ロジックーーー

		//アプリ初期化IF
		public bool ReloadOed(string _filePath){
			reloadFile(_filePath);
			selectTextKtb();
			return true;
		}

		public bool reloadFile(string _filePath) {
			filePath.Text = _filePath;
			using(var sr = new StreamReader(_filePath)) {
				if(sr != null) {
					_textKbt.Text = sr.ReadToEnd();
				}
			}
			return true;
		}
		//アプリ初期化IFーーー

		//イベントハンドラ
		private void gotFocusHandler(object? sender, EventArgs e){
			_textKbt.Select();
		}
		private void selectCommandKtb(){
			_commandKtb.Select();
			SendKeys.Send("i");
		}
		private void selectTextKtb(){
			_commandKtb.Clear();
			_textKbt.Select();
		}
		private void recieveCommand(){
			//controler.command.RecieveCommand(this);
		}
		//イベントハンドラーーー
	}
}