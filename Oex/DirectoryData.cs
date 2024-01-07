using System.Diagnostics;

namespace Oex {
	internal class DirectoryData {
		protected List<string> fileList;
		protected List<string> directoryList;

		internal DirectoryData(string _path){
			MoveCurrentPath(_path);
			fileList = new List<string>();
			directoryList = new List<string>();
			RefleshList();
		}

		//情報提供IF
		internal string GetCurrentPath(){
			return System.Environment.CurrentDirectory; 
		}
		internal int GetItemCount(){
			return directoryList.Count + fileList.Count;
		}
		internal string GetItemName(int _itemIdx){
			if(_itemIdx < directoryList.Count){
				return directoryList[_itemIdx];
			}

			int fileIdx = _itemIdx - directoryList.Count;
			if(fileIdx < fileList.Count){
				return fileList[fileIdx];
			}
			return "";
		}
		internal string GetFileItemName(int _fileIdx){
			if(_fileIdx < 0 || fileList.Count <= _fileIdx)
				return "";
			return fileList[_fileIdx];
		}
		internal string GetDirectoryItemName(int _directoryIdx){
			if(_directoryIdx < 0 || directoryList.Count <= _directoryIdx)
				return "";
			return directoryList[_directoryIdx];
		}
		internal List<string> GetAllFileName(){
			return directoryList.Concat<string>(fileList).ToList();
		}
		//情報提供IF---

		//情報更新IF
		internal bool RefleshList(){
			try {
				fileList = Directory.GetFiles(System.Environment.CurrentDirectory).ToList();
				directoryList = Directory.GetDirectories(System.Environment.CurrentDirectory).ToList();
			}
			catch(UnauthorizedAccessException){
				return false;
			}

			if(fileList.Count != 0){ 
				for(int i = 0; i < fileList.Count; i++){
					fileList[i] = Path.GetFileName(fileList[i]);
				}
			}
			if(directoryList.Count != 0) {
				for(int i = 0; i < directoryList.Count; i++) {
					directoryList[i] = Path.GetFileName(directoryList[i]);
				}
			}
			return true;
		}

		internal bool MoveCurrentPath(string _path){
			if(_path == null)
				return false;
			if(_path == "")
				return false;

			if(Directory.Exists(_path)) {
				System.Environment.CurrentDirectory = _path;
				RefleshList();
				return true;
			}
			return false;
		}
		internal bool MoveUpCurrentPath(){
			System.Environment.CurrentDirectory = Path.GetFullPath(@"..\", System.Environment.CurrentDirectory);
				RefleshList();
			return true;
		}
		internal bool MoveDownCurrentPathTo(string _target) {
			string nextPath;
			try {
				nextPath = Path.GetFullPath(@".\" + _target + @"\", System.Environment.CurrentDirectory);

				if(Directory.Exists(nextPath)) {
					System.Environment.CurrentDirectory = nextPath;
				}
			}
			catch(ArgumentException){
			}
			catch(UnauthorizedAccessException){
				return false;
			}
			RefleshList();
			return true;
		}
		//情報更新IF---
	}
}
