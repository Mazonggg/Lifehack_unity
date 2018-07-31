
using Lifehack.Model.Prozess;
using Lifehack.Spiel.GuiModul.Popup;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.GuiModul.Form.InputAdapter.Model.Prozess {

    public class TeilaufgabeFormInput : ButtonFormInput<Teilaufgabe> {

        protected override string GetKurzInfo() {
            return this.eintrag.Dialog.MenueText;
        }

        public override void OnPointerClick(PointerEventData eventData) {
            FormModul.Instance.GetInhalt(this.eintrag);
        }
    }
}

