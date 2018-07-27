using UnityEngine;
using System.Collections;
using Lifehack.Model;

namespace Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter {

    abstract public class PopupEintrag<T> : IPopupEintragAdapter where T : IDatenbankEintrag {

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

