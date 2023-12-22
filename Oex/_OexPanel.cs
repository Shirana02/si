using kvi;
using System.Diagnostics;

namespace Oex {
	public class _OexPanel :Control {
		internal int displayNum;
		private OexControler controler;
		public  OexEvent ExpandEvent{ get; private set; }

		RichTextBox currentPath;
//		List<FileDisplayTB> ___displayList;
		FlowLayoutPanel displayList;
		Size displayListAreaSize;

		public _OexPanel(Size _size, Point _location){
			ExpandEvent = new OexEvent();

			currentPath = new RichTextBox();
			currentPath.Height = currentPath.Font.Height + 2;
			currentPath.BackColor = Color.Red;
			currentPath.Text = "dummy path";
			currentPath.Multiline = false;
			currentPath.Dock = DockStyle.Top;
			this.Controls.Add(currentPath);

			displayList = new FlowLayoutPanel();
			displayList.Size = this.ClientSize;
			displayList.Top = currentPath.Bottom;
			displayList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			displayList.FlowDirection = FlowDirection.TopDown;
			this.Controls.Add(displayList);
			displayList.BringToFront();

			FileDisplayTB item0 = new FileDisplayTB("hogefugaereki");
			//item0.Dock = DockStyle.Left;
			item0.Text = "hogeeeeeeeeeeeeeeeeeeege";
			displayList.Controls.Add(item0);

			KviTextBox kvi = new KviTextBox();
			kvi.Text = "hohohhoh";
			displayList.Controls.Add(kvi);


			TextBox tk = new TextBox();
			tk.Dock = DockStyle.Left;
			displayList.Controls.Add(tk);
			tk.Text = "tk1";
			TextBox tk2 = new TextBox();
			displayList.Controls.Add(tk2);
			tk2.Text = "tk2";

//			this.SetSize(_size);
//			this.SetLocation(_location);


			controler = new OexControler(this);
			//PointCursor(0);
		}

		protected override void OnKeyDown(KeyEventArgs e){
			base.OnKeyDown(e);
			controler.RecieveKey(e.KeyData, this);
		}

/*
		//フォーム内表示調整ロジック
		/// <summary>
		/// OexPanelの位置情報を更新し、内部の各コントロールの位置を計算する。
		/// 計算された情報は各コントロールの位置プロパティとして更新される。
		/// </summary>
		/// <param name="_location"></param>
		/// <returns></returns>
		public bool SetLocation(Point _location){
			Location = _location;
			refreshCurrentPathAreaLocation();
			refreshDisplayListItemLocation();
			return true;
		}

		/// <summary>
		/// OexPanelのサイズ情報から、内部に配置する各コントロールのサイズと個数を計算し、必要ならコントロールを追加する。
		/// </summary>
		/// <param name="_size"></param>
		/// <returns></returns>
		public bool SetSize(Size _size){
			Size = _size;
			refreshCurrentPathAreaSize();
			refreshDisplayListAreaSize();
			refreshFileItemSize();
			refreshFileItemDisplayNum();
			adjustDisplayListLength();
			return true;
		}
		//サイズ調整用メソッドたち
		private bool refreshCurrentPathAreaSize(){
			currentPath.Size = new Size(Size.Width, currentPath.Lines.Length * Font.Height + 2);
			return true;
		}
		private bool refreshDisplayListAreaSize(){
			int width = Size.Width;
			int height = Size.Height - currentPath.Size.Height;
			displayListAreaSize = new Size(width, height);
			return true;
		}
		private bool refreshFileItemSize(){
			foreach(FileDisplayTB item in displayList){
				item.SetSize(displayListAreaSize.Width - 2, Font.Height + 2);
			}
			return true;
		}
		private bool refreshFileItemDisplayNum(){
			displayNum = displayListAreaSize.Height / displayList[0].ktb.Height;
			return true;
		}
		private bool adjustDisplayListLength(){
			while(displayList.Count < displayNum) { 
				displayList.Add(new FileDisplayTB("",FileItemType.File));
				displayList[displayList.Count - 1].SetSize(displayList[0].ktb.Size);
				this.Controls.Add(displayList[displayList.Count - 1].ktb);
			}
			if(displayList.Count > displayNum){
				displayList.RemoveRange(displayNum, displayList.Count - displayNum);
			}
			return true;
		}

		//表示場所調整用メソッドたち
		private bool refreshCurrentPathAreaLocation(){
			currentPath.Location = this.Location;
			return true;
		}
		private bool refreshDisplayListItemLocation(){
			int locationHoriOffset = currentPath.Location.X;
			int locationVertOffset = currentPath.Location.Y + currentPath.Height;
			foreach(FileDisplayTB item in displayList){
				item.ktb.Location = new Point(locationHoriOffset, locationVertOffset);
				locationVertOffset += item.ktb.Size.Height;
			}
			return true;
		}
		//フォーム内表示調整ロジックーーー

*/
		//カーソル操作IF
		internal bool PointCursor(int _idx){
			SelectionStart = _idx;
			SelectionLength = 1;
			refreshCursorDisplay(); 
			return true;
		}
		internal bool SelectRange(int _startIdx, int _endIdx){
			SelectionStart = _startIdx;
			SelectionLength = _endIdx - SelectionStart;
			refreshCursorDisplay(); 
			return true;
		}
		private int selectionStart;
		internal int SelectionStart{
			get{ return selectionStart; }
			private set{ 
				selectionStart = value; 
				refreshCursorDisplay(); 
			}
		}
		private int selectionLength;
		internal int SelectionLength{
			get{ return selectionLength; }
			private set{ 
				selectionLength = value; 
			}
		}
		private bool refreshCursorDisplay(){
			for(int i = 0; i < displayList.Controls.Count; i++){
				if(SelectionStart <= i && i < SelectionStart + SelectionLength){
					FileDisplayTB? listitem = ControlToFileDisplayTB(displayList.Controls[i]);
					if(listitem != null){ 
						listitem.BackColor = Color.Aqua;
					}
				}
				else{
					//displayList[i].ktb.BackColor = this.BackColor;
					FileDisplayTB? listitem = ControlToFileDisplayTB(displayList.Controls[i]);
					if(listitem != null){ 
						listitem.BackColor = Color.Yellow;
					}
				}
			}
			return true;
		}
		//カーソル操作IFーーー

		//描画更新IF
		internal bool refreshDirectoryPathDisplay(string _path){
			currentPath.Text = _path;
			return true;
		}
		internal bool refreshItemDisplay(List<string> _items){
			for(int i = 0; i < displayList.Controls.Count; i++){
				FileDisplayTB? listitem = ControlToFileDisplayTB(displayList.Controls[i]);
				if(listitem != null) {
					listitem.Update();
					if(_items.Count <= i) {
						listitem.Text = "";
						break;
					}
					listitem.Text = _items[i];
				}
			}
			return true;
		}
		//描画更新IFーーー

		//その他
		FileDisplayTB? ControlToFileDisplayTB(Control _ctrl){
			if(_ctrl is FileDisplayTB){
				return (FileDisplayTB)_ctrl;
			}
			return null;
		}
		//その他ーーー
		
	}
}