
using Lifehack.Model;
using Lifehack.Model.Prozess;
using UnityEngine.EventSystems;

namespace Lifehack.Anwendung.Spiel.Popup.PopupEintrag.Model.Prozess {

    public class ItemPopupEintragAdapter : DatenbankEintragPopupEintragAdapter<Item> {

        protected override string GetKurzInfo() {
            return this.eintrag.Name;
        }
    }
}

