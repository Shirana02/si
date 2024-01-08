namespace Oed {
	internal class CommandLogic {
		internal bool RecieveCommand(OedPanel _target){
			switch(_target.ktb_commandArea.Text) {
				case "q":
					_target.ExpandEvent.FileClose();
					break;
				default:
					break;
			}
			return true;
		}
	}
}
