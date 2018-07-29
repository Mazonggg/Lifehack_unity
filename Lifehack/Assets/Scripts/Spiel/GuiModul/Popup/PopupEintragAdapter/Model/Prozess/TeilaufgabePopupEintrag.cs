
using Lifehack.Model.Prozess;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter.Model.Prozess {

    public class TeilaufgabePopupEintrag : DatenbankEintragPopupEintrag<Teilaufgabe> {

        protected override string GetKurzInfo() {
            return this.eintrag.Dialog.MenueText;
        }
    }
}

