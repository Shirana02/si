using kvi;

namespace Oex {
	public partial class OexPanel :UserControl {
		private int fileItemCount;
		private int selectionStartIdx;
		private int selectionEndIdx;

		private OexControler controler;

		public OexPanel() {
			InitializeComponent();
			controler = new OexControler(this);
		}

		//CtrlEvent
		private void KeyDownEvent_OexLogic(object? sender, KeyEventArgs e){
			base.OnKeyDown(e);
			controler.RecieveKey(e.KeyData, this);
		}
		private void FocusEvent_ToDummyFocusCtrl(object? sender, EventArgs e){
		}
		//CtrlEvent---

		//Prop
		public string FocusedItemName{
			get{ return flp_DisplayList.Controls[SelectionStartIdx].Text; }
		}
		public int SelectionStartIdx{
			get { return selectionStartIdx; }
			set {
				if(value < 0){ 
					selectionStartIdx = 0;
				}
				else if(fileItemCount <= value){
					selectionStartIdx = fileItemCount;
				}
				else{
					selectionStartIdx = value;
				}
				focusFile(selectionStartIdx);
			}
		}
		public int FileItemCount{
			get { return fileItemCount; }
		}
		public int SelectionEndIdx{
			get { return selectionEndIdx; }
			set {
				if(value < 0){ 
					selectionEndIdx = 0;
				}
				else if(fileItemCount <= value){
					selectionEndIdx = fileItemCount;
				}
				else{
					selectionEndIdx = value;
				}
			}
		}
		//Prop---

		//Method
		public bool ScrollFileList(int _idx){
			if(_idx < 0)
				return false;
			if(fileItemCount <= _idx)
				return false;

			flp_DisplayList.ScrollControlIntoView(flp_DisplayList.Controls[_idx]);
			return true;
		}

		public void UpdateFileList(List<string> _files){
			flp_DisplayList.Controls.Clear();
			if(_files.Count == 0){
				flp_DisplayList.Controls.Add(new KviTextBox());
				flp_DisplayList.Controls[0].Height = flp_DisplayList.Controls[0].Font.Height + 5;
				flp_DisplayList.Controls[0].Text = "---NoFile---";
				flp_DisplayList.Controls[0].GotFocus += FocusEvent_ToDummyFocusCtrl;
				return;
			}

			int i = 0;
			foreach(string item in _files){
				flp_DisplayList.Controls.Add(new KviTextBox());
				flp_DisplayList.Controls[i].Height = flp_DisplayList.Controls[i].Font.Height + 4;
				flp_DisplayList.Controls[i].Text = item;
				flp_DisplayList.Controls[i].GotFocus += FocusEvent_ToDummyFocusCtrl;
				i++;
			}
			fileItemCount = _files.Count;
		}

		public void FocusPanel(){
			txt_DummyFocusCtrl_DisplayList.Focus();		
		}
		//Method---

		//method
		private void focusFile(int _idx){
			for(int i = 0; i < fileItemCount; i++){
				if(i == _idx){
					flp_DisplayList.Controls[i].BackColor = SystemColors.ActiveCaption;
				}
				else{
				}
			}
		}
		//method---

		private void OexPanel_Load(object sender, EventArgs e) {
		}

	}
}
