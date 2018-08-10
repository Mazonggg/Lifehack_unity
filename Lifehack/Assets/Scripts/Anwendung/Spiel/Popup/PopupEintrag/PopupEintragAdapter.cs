using Lifehack.Model;
using Lifehack.Model.Konstanten;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Anwendung.Spiel.Popup.PopupEintrag {

    abstract public class PopupEintragAdapter<T> : ModulEintragAdapter<T>, IPopupEintrag<T>, IPopupTitelgeber, IPointerClickHandler where T : IDatenbankEintrag{
        
        public override string GetEintragInhalt() {
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

