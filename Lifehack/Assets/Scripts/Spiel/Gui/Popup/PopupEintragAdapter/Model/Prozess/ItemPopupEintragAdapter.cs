
using Lifehack.Model;
using Lifehack.Model.Prozess;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.Gui.Popup.PopupEintragAdapter.Model.Prozess {

    public class ItemPopupEintragAdapter : DatenbankEintragPopupEintragAdapter<Item> {

        protected override string GetKurzInfo() {
            return this.eintrag.Name;
        }
    }
}

