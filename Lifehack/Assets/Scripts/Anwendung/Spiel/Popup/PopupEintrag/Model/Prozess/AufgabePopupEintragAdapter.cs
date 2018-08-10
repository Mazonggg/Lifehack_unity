
using Lifehack.Model.Prozess;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Anwendung.Spiel.Popup.PopupEintrag.Model.Prozess {

    public class AufgabePopupEintragAdapter : DatenbankEintragPopupEintragAdapter<Aufgabe> {

        protected override string GetKurzInfo() {
            return this.eintrag.Bezeichnung;
        }
    }
}

