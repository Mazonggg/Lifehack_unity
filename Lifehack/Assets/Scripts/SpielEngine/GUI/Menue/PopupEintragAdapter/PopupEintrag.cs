using UnityEngine;
using System.Collections;
using Lifehack.Model;

namespace Lifehack.GUI.Menue.PopupEintragAdapter {

    abstract public class PopupEintrag<T> : IPopupEintragAdapter {

        protected T eintrag;

        public PopupEintrag(T eintrag) {
            this.eintrag = eintrag;
        }
        public string GetPopupEintragText() {
            return this.GetKurzInfo();
        }

        protected abstract string GetKurzInfo();
    }
}