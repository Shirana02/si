
namespace Oex {
	internal static class CursorMoving {
		public static int MoveVertical(int _start, int _step, int _fileCount){
			if(_fileCount <= _start + _step){
				return _fileCount - 1;
			}
			if(_start + _step < 0){
				return 0;
			}
			return _start + _step;
		}
	}
}
