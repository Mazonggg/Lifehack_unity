
using Lifehack.Model;
using Lifehack.Model.Konstanten;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.Gui.Popup.PopupEintragAdapter.Model {

    abstract public class DatenbankEintragPopupEintragAdapter<T> : PopupEintragAdapter<T> where T : IDatenbankEintrag {

        public override void OnPointerClick(PointerEventData eventData) {
            FormModulAdapter.Instance.GetInhalt(this.eintrag);
        }

        public override string GetPopupTitel() {
            return StringHelfer.Ucfirst(EnumHandler.AlsString(this.eintrag.Tabelle()));
        }
    }
}

