
using Lifehack.Model;
using UnityEngine.EventSystems;

namespace Lifehack.Anwendung.Spiel.Menue.MenueEintrag {

    public interface IMenueEintrag : IModulEintrag, IPointerClickHandler {
        IDatenbankEintrag Eintrag { set; }
    }
}
