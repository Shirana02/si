
using System.Diagnostics;

namespace kvi {
	public class KviTextBox :RichTextBox {
		private KviControler controler;
		public  KviEvent ExpandEvent{ get; private set; }
		public void AddOverEscEvent(Action e){
			ExpandEvent.OverEscapeHandler += e;
		}
		public void RemoveOverEscEvent(Action e){
			ExpandEvent.OverEscapeHandler -= e;
		}

		public KviTextBox() :base(){
			controler = new KviControler();
			ExpandEvent = new KviEvent();
			SetStyle(ControlStyles.ResizeRedraw, true);
		}

		protected override void OnGotFocus(EventArgs e) {
			base.OnGotFocus(e);
			controler.Mode.IntoNormal();
			ReadOnly = true;
			Debug.Print(this.Name);
		}

		protected override void OnKeyDown(KeyEventArgs e) {
			base.OnKeyDown(e);
			if(controler.Mode.Mode != EditMode.Insert){
				ReadOnly = true;
			}
			else{
				ReadOnly = false;
			}

			controler.RecieveKey(e.KeyData, this);
		}

		//カーソル操作IF
			internal bool PointCursor(int _idx){
				SelectionStart = _idx;
				SelectionLength = 0;
				return true;
			}
			internal bool SelectRange(int _startIdx, int _endIdx){
				SelectionStart = _startIdx;
				SelectionLength = _endIdx - SelectionStart;
				return true;
			}

		//情報取得IF
			internal int GetSelectionEnd(){
				return SelectionStart + SelectionLength;
			}
	}
}
