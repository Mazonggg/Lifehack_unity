
using Lifehack.Model.Prozess;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter.Model.Prozess {

    public class AufgabePopupEintrag : PopupEintrag<Aufgabe> {

        protected override string GetKurzInfo() {
            return this.eintrag.Bezeichnung;
        }

        public override void OnPointerClick(PointerEventData eventData) {
            Debug.Log("AufgabePopupEintrag.OnPointerClick: " + this.eintrag);
        }
    }
}

