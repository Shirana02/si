
namespace Oex {
	internal static class CursorMoving {
	/*
		public static int MoveHolizontal(int _currentIdx, int _step, string _field){
			int theoreticDst;
			int headIdx, tailIdx;

			headIdx = searchCurrentHead(_currentIdx, _field);
			theoreticDst = _currentIdx + _step;

			if(theoreticDst < headIdx){
				return headIdx;
			}

			tailIdx = _field.IndexOf('\n', _currentIdx);
			if(tailIdx == -1){
				tailIdx = _field.Length;
			}

			if(tailIdx < theoreticDst){
				return tailIdx;
			}
			return theoreticDst;
		}
		*/

		public static int MoveVertical(int _start, int _step, int _fileCount){
			if(_fileCount <= _fileCount + _step){
				return _fileCount - 1;
			}
			if(_start + _step < 0){
				return 0;
			}
			return _start + _step;
		}
	}
}
