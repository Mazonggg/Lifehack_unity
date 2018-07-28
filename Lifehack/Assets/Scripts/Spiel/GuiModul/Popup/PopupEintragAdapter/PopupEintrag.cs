using UnityEngine;

namespace Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter {

    abstract public class PopupEintrag<T> : MonoBehaviour, IPopupEintragAdapter {

        protected T eintrag;
        public T Eintrag {
            set { this.eintrag = value; }
        }

        public string GetPopupEintragText() {
            return this.GetKurzInfo();
        }

        protected abstract string GetKurzInfo();
    }
}

