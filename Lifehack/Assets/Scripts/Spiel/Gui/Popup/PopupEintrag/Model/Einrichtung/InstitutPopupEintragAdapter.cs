
using Lifehack.Model.Einrichtung;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.Gui.Popup.PopupEintrag.Model.Einrichtung {

    public class InstitutPopupEintragAdapter : DatenbankEintragPopupEintragAdapter<Institut> {

        protected override string GetKurzInfo() {
            return this.eintrag.Name;
        }
    }
}

