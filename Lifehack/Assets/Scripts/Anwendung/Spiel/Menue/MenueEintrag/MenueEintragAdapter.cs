
using Lifehack.Model;
using Lifehack.Model.Konstanten;
using Lifehack.Anwendung.Spiel.Popup;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Anwendung.Spiel.Menue.MenueEintrag {

    public class MenueEintragAdapter : MonoBehaviour, IMenueEintrag {

        protected IDatenbankEintrag eintrag;
        public IDatenbankEintrag Eintrag {
            set { this.eintrag = value; Debug.Log("tabelle:\n" + this.eintrag); }
        }

        public string GetEintragInhalt() {
            return StringHelfer.Ucfirst(EnumHandler.AlsString(this.eintrag.Tabelle()));
        }

        public void OnPointerClick(PointerEventData eventData) {
            Debug.Log("MenueEintragAdapter.OnPointerClick(): " + this.eintrag);
            // TODO Warum verschwindet der Wert für tabelle hier zwischen setter und abruf???
            PopupModul.Instance.GetInhalt(ModelHandler.Instance.GetEintraegeFuerTabelle(TabellenName.ITEM));
        }
    }
}

