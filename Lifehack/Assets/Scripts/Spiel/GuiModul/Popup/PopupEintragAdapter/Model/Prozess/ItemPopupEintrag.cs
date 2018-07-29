
using Lifehack.Model;
using Lifehack.Model.Prozess;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter.Model.Prozess {

    public class ItemPopupEintrag : DatenbankEintragPopupEintrag<Item> {

        protected override string GetKurzInfo() {
            return this.eintrag.Name;
        }
    }
}

