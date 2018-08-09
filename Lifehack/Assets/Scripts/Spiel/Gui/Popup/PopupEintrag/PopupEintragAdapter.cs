using Lifehack.Model.Konstanten;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.Gui.Popup.PopupEintrag {

    abstract public class PopupEintragAdapter<T> : MonoBehaviour, IPopupEintrag<T>, IPopupTitelgeber, IPointerClickHandler {

        protected T eintrag;
        public T Eintrag {
            set { this.eintrag = value; }
        }

        public string GetEintragText() {
            return StringHelfer.Ucfirst(this.GetKurzInfo());
        }

        public string GetPopupEintragTitel() {
            return StringHelfer.Ucfirst(this.GetKurzInfo());
        }

        abstract protected string GetKurzInfo();
        abstract public void OnPointerClick(PointerEventData eventData);
        abstract public string GetPopupTitel();
    }
}

