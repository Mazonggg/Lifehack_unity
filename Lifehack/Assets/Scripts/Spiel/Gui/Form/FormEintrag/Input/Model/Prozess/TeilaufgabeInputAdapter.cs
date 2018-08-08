
using System.Collections.Generic;
using Lifehack.Model;
using Lifehack.Model.Prozess;
using Lifehack.Spiel.Gui.Popup;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.Gui.Form.FormEintrag.Input.Model.Prozess {

    public class TeilaufgabeInputAdapter : ButtonInputAdapter<Teilaufgabe> {

        protected override string GetKurzInfo() {
            return this.eintrag.Dialog.MenueText;
        }

        public override void OnPointerClick(PointerEventData eventData) {
            FormModulAdapter.Instance.GetInhalt(new List<IDatenbankEintrag>() { this.eintrag });
        }
    }
}
