
using Lifehack.Model;
using Lifehack.Model.Konstanten;
using Lifehack.Spiel.Gui.Form;
using Lifehack.Spiel.Gui.Popup;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.Gui.Menue.MenueEintrag {

    public class MenueEintragAdapter : MonoBehaviour, IMenueEintrag {

        protected TabellenName tabelle;
        public TabellenName Tabelle {
            set { this.tabelle = value; Debug.Log("tabelle:\n" + this.tabelle); }
        }

        public string GetEintragText() {
            return StringHelfer.Ucfirst(EnumHandler.AlsString(this.tabelle));
        }

        public void OnPointerClick(PointerEventData eventData) {
            Debug.Log("MenueEintragAdapter.OnPointerClick(): " + this.tabelle);
            // TODO HAE?
            PopupModulAdapter.Instance.GetInhalt(ModelHandler.Instance.GetEintraegeFuerTabelle(TabellenName.ITEM));
        }
    }
}

