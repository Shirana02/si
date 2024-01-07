
namespace Oex {
	internal class OexControler {
		internal OexMode Mode { get; private set; }
		private DirectoryData dir;

		internal OexControler(OexPanel _oexPanel){
			dir = new DirectoryData(Environment.CurrentDirectory);
			Mode = new OexMode();
			_oexPanel.UpdateFileList(dir.GetAllFileName());
			_oexPanel.UpdateCurrentPathDisplay(dir.GetCurrentPath());
		}

		internal void RecieveFocus(OexPanel _oexPanel){
			if(Mode.Mode == OexModes.Normal){
				_oexPanel.FocusPanel();
			}
		}

		internal bool RecieveKey(Keys _key, OexPanel _oexPanel){
			if(_key == (Keys.Control | Keys.OemOpenBrackets)){
				if(Mode.IntoNormal()){
					_oexPanel.SelectionEndIdx = _oexPanel.SelectionStartIdx;
				}
				return true;
			}

			switch(_key) {
				case (Keys.Control | Keys.W):
					event_Ctrl_w(_oexPanel);
					break;
				case Keys.Enter:
					event_Enter(_oexPanel);
					break;
				case Keys.H:
					event_h(_oexPanel);
					break;
				case Keys.L:
					event_l(_oexPanel);
					break;
				case Keys.J:
					event_j(_oexPanel);
					break;
				case Keys.K:
					event_k(_oexPanel);
					break;
				case Keys.I:
					event_i(_oexPanel);
					break;
				default:
					break;
			}
			return true;
		}

		private string getFocusedFullPath(OexPanel _oexPanel){ 
			return 
				dir.GetCurrentPath()
				+ @"\"
				+ _oexPanel.FocusedItemName;
		}
		//private List<string> getSelectedItemFullPath(OexPanel _oexPanel){}
		private void event_Ctrl_w(OexPanel _oexPanel){
			switch(Mode.Mode) {
				case OexModes.Normal:
					//_oexPanel.ExpandEvent.OverEsc();
					break;
				case OexModes.Insert:
					break;
				case OexModes.Select:
					break;
				default:
					break;
			}
		}
		private void event_Enter(OexPanel _oexPanel){
			switch(Mode.Mode) {
				case OexModes.Normal:
					string filePath = getFocusedFullPath(_oexPanel);
					if(File.Exists(filePath)) {
						_oexPanel.ExpandEvent.FileOpen(filePath);
					}
					break;
				case OexModes.Insert:
					break;
				case OexModes.Select:
					break;
				default:
					break;
			}
		}
		private void event_i(OexPanel _oexPanel){
			switch(Mode.Mode) {
				case OexModes.Normal:
					Mode.IntoInsert();
					break;
				case OexModes.Insert:
					break;
				case OexModes.Select:
					break;
				default:
					break;
			}
		}

		private void event_l(OexPanel _oexPanel) {
			switch(Mode.Mode) {
				case OexModes.Normal:
					dir.MoveDownCurrentPathTo(_oexPanel.FocusedItemName);
					_oexPanel.UpdateFileList(dir.GetAllFileName());
					_oexPanel.SelectionStartIdx = 0;
					_oexPanel.SelectionEndIdx = 0;
					_oexPanel.ScrollFileList(0);
					_oexPanel.PaintSelectedItem();
					_oexPanel.UpdateCurrentPathDisplay(dir.GetCurrentPath());
					break;
				case OexModes.Insert:
					break;
				case OexModes.Select:
					break;
				default:
					break;
			}
		}
		private void event_j(OexPanel _oexPanel) {
			switch(Mode.Mode) {
				case OexModes.Normal:
					int dst = CursorMoving.MoveVertical(_oexPanel.SelectionStartIdx, 1, _oexPanel.FileItemCount);
					_oexPanel.SelectionStartIdx = dst;
					_oexPanel.SelectionEndIdx = dst;
					_oexPanel.PaintSelectedItem();
					break;
				case OexModes.Insert:
					break;
				case OexModes.Select:
					break;
				default:
					break;
			}
		}
		private void event_k(OexPanel _oexPanel) {
			switch(Mode.Mode) {
				case OexModes.Normal:
					int dst = CursorMoving.MoveVertical(_oexPanel.SelectionStartIdx, -1, _oexPanel.FileItemCount);
					_oexPanel.SelectionStartIdx = dst;
					_oexPanel.SelectionEndIdx = dst;
					_oexPanel.PaintSelectedItem();
					break;
				case OexModes.Insert:
					break;
				case OexModes.Select:
					break;
				default:
					break;
			}
		}
		private void event_h(OexPanel _oexPanel) {
			switch(Mode.Mode) {
				case OexModes.Normal:
					dir.MoveUpCurrentPath();
					_oexPanel.UpdateFileList(dir.GetAllFileName());
					_oexPanel.SelectionStartIdx = 0;
					_oexPanel.SelectionEndIdx = 0;
					_oexPanel.ScrollFileList(0);
					_oexPanel.PaintSelectedItem();
					_oexPanel.UpdateCurrentPathDisplay(dir.GetCurrentPath());
					break;
				case OexModes.Insert:
					break;
				case OexModes.Select:
					break;
				default:
					break;
			}
		}
	}
}
