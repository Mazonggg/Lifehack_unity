
using Lifehack.Model;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter.Model {

    abstract public class DatenbankEintragPopupEintrag<T> : PopupEintrag<T> where T : IDatenbankEintrag {

        public override void OnPointerClick(PointerEventData eventData) {
            FormModul.Instance.GetInhalt(this.eintrag);
        }
    }
}

