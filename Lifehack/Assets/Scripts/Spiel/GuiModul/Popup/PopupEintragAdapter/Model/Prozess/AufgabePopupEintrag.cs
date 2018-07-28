
using Lifehack.Model.Prozess;
using UnityEngine;

namespace Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter.Model.Prozess {

    public class AufgabePopupEintrag : PopupEintrag<Aufgabe> {

        protected override string GetKurzInfo() {
            return this.eintrag.Bezeichnung;
        }
    }
}

