using Lifehack.Model.Konstanten;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.Gui.Popup.PopupEintragAdapter {

    abstract public class PopupEintragAdapter<T> : MonoBehaviour, IPopupEintrag, IPopupTitelgeber, IPointerClickHandler {

        protected T eintrag;
        public T Eintrag {
            set { this.eintrag = value; }
        }

        public string GetPopupEintragText() {
            return StringHelfer.Ucfirst(this.GetKurzInfo());
        }

        public string GetPopupEintragTitel() {
            throw new System.NotImplementedException();
        }

        abstract protected string GetKurzInfo();
        abstract public void OnPointerClick(PointerEventData eventData);
        abstract public string GetPopupTitel();
    }
}

