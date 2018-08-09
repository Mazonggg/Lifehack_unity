
using Lifehack.Model;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.Gui.Menue.MenueEintrag {

    public interface IMenueEintrag : IModulEintrag, IPointerClickHandler {
        IDatenbankEintrag Eintrag { set; }
    }
}
