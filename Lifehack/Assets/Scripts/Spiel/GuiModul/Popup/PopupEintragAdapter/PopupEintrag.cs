using Lifehack.Model.Konstanten;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter {

    abstract public class PopupEintrag<T> : MonoBehaviour, IPopupEintragAdapter, IPointerClickHandler {

        protected T eintrag;
        public T Eintrag {
            set { this.eintrag = value; }
        }

        public string GetPopupEintragText() {
            return StringHelfer.Ucfirst(this.GetKurzInfo());
        }

        protected abstract string GetKurzInfo();

        public virtual void OnPointerClick(PointerEventData eventData) {
            Debug.Log("PopupEintrag.OnPointerClick: " + this.eintrag.ToString());
        }
    }
}

