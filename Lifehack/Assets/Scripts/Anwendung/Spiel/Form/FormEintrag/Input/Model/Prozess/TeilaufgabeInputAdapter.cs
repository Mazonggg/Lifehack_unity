
using System.Collections.Generic;
using Lifehack.Model;
using Lifehack.Model.Prozess;
using Lifehack.Anwendung.Spiel.Popup;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Anwendung.Spiel.Form.FormEintrag.Input.Model.Prozess {

    public class TeilaufgabeInputAdapter : ButtonInputAdapter<Teilaufgabe> {

        protected override string GetKurzInfo() {
            return this.eintrag.Dialog.MenueText;
        }

        public override void OnPointerClick(PointerEventData eventData) {
            FormModul.Instance.GetInhalt(new List<IDatenbankEintrag>() { this.eintrag });
        }
    }
}

