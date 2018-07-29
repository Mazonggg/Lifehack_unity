
using Lifehack.Model.Einrichtung;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter.Model.Einrichtung {

    public class InstitutPopupEintrag : DatenbankEintragPopupEintrag<Institut> {

        protected override string GetKurzInfo() {
            return this.eintrag.Name;
        }
    }
}

