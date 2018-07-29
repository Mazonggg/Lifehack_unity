
using Lifehack.Model.Konstanten;
using Lifehack.Model.Stadtplan;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter.Model.Prozess {

    public class KartenelementPopupEintrag : PopupEintrag<Kartenelement> {

        const string betreten = " betreten";

        protected override string GetKurzInfo() {
            return EnumHandler.AlsString(this.eintrag.Tabelle()) + KartenelementPopupEintrag.betreten;
        }

        public override void OnPointerClick(PointerEventData eventData) {
            Debug.Log("KartenelementPopupEintrag.OnPointerClick: " + this.eintrag);
        }
    }
}

