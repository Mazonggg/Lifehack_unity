
using System.Collections.Generic;
using Lifehack.Model;
using Lifehack.Model.Konstanten;
using Lifehack.Spiel.Gui.Form;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.Gui.Popup.PopupEintrag.Model {

    abstract public class DatenbankEintragPopupEintragAdapter<T> : PopupEintragAdapter<T> where T : IDatenbankEintrag {

        public override void OnPointerClick(PointerEventData eventData) {
            FormModul.Instance.GetInhalt(new List<IDatenbankEintrag>() { this.eintrag });
        }

        public override string GetPopupTitel() {
            return StringHelfer.Ucfirst(EnumHandler.AlsString(this.eintrag.Tabelle()));
        }
    }
}

