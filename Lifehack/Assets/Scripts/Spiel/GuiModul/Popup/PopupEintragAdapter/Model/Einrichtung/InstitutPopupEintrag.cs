
using Lifehack.Model.Einrichtung;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter.Model.Einrichtung {

    public class InstitutPopupEintrag : PopupEintrag<Institut> {

        protected override string GetKurzInfo() {
            return this.eintrag.Name;
        }

        public override void OnPointerClick(PointerEventData eventData) {
            Debug.Log("InstitutPopupEintrag.OnPointerClick: " + this.eintrag);
        }
    }
}

