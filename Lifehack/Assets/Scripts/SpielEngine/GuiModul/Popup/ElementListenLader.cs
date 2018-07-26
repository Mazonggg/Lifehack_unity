
using Lifehack.GUI.Popup.PopupEintragAdapter;
using Lifehack.Model;
using Lifehack.Model.Einrichtung;
using Lifehack.Model.Konstanten;
using Lifehack.Model.Prozess;
using UnityEngine;
using UnityEngine.UI;

namespace Lifehack.GUI.Popup {

    public class ElementListenLader : MonoBehaviour {

        private TabellenName tabellenName;
        public TabellenName TabellenName {
            set { this.tabellenName = value; }
        }
        public GameObject popupEintragPrefab;

        private void Start() {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(this.InitListe);
        }

        private void InitListe() {
            IPopupEintragAdapter[] eintragAdapter = new IPopupEintragAdapter[] { };
            switch (this.tabellenName) {
                case TabellenName.INSTITUT:
                    eintragAdapter = SimplePopupEintragFabrik.ErzeugePopupEintraege<Institut>(ModelHandler.Instance.Institute);
                    break;
                case TabellenName.ITEM:
                    eintragAdapter = SimplePopupEintragFabrik.ErzeugePopupEintraege<Item>(ModelHandler.Instance.Items);
                    break;
                case TabellenName.AUFGABE:
                    eintragAdapter = SimplePopupEintragFabrik.ErzeugePopupEintraege<Aufgabe>(ModelHandler.Instance.Aufgaben);
                    break;
            }
            foreach (IPopupEintragAdapter eintrag in eintragAdapter) {
                GameObject popupEintrag = Instantiate(this.popupEintragPrefab);
                popupEintrag.GetComponent<PopupEintragController>().InitPopupEintragController(eintrag);
            }
        }
    }
}

