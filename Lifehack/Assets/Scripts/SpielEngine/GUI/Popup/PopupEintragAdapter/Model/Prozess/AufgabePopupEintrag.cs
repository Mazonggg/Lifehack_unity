using UnityEngine;
using System.Collections;
using Lifehack.Model.Prozess;

namespace Lifehack.GUI.Popup.PopupEintragAdapter.Model.Prozess {

    public class AufgabePopupEintrag : PopupEintrag<Aufgabe> {

        public AufgabePopupEintrag(Aufgabe eintrag) : base(eintrag) { }

        protected override string GetKurzInfo() {
            return this.eintrag.Bezeichnung;
        }
    }
}

