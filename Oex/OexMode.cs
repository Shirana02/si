
namespace Oex {
	internal class OexMode {
		internal OexModes Mode { get; private set; }
		public OexMode() {
			Mode = OexModes.Normal;
		}

		public bool IntoNormal() {
			if(Mode == OexModes.Normal) {
				return false;
			}

			Mode = OexModes.Normal;
			return true;
		}
		public bool IntoSelect() {
			if(Mode != OexModes.Normal) {
				return false;
			}

			Mode = OexModes.Select;
			return true;
		}
		public bool IntoInsert() {
			if(Mode != OexModes.Normal) {
				return false;
			}

			Mode = OexModes.Insert;
			return true;
		}
	}

	internal enum OexModes {
		Normal,
		Insert,
		Select,
	}
}
