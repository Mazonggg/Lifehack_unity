
using Lifehack.GUI.Menue.PopupEintragAdapter;
using Lifehack.Model.Einrichtung;
using Lifehack.Model.Enum;
using Lifehack.Model.Prozess;
using UnityEngine;
using UnityEngine.UI;

namespace Lifehack.GUI.Menue {

    public class ElementListenLader : MonoBehaviour {

        public TabellenName tabellenName;
        public GameObject popupEintragPrefab, popupEintragContainer;

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
                ModelHandler.Log("foreach: " + eintrag.GetPopupEintragText());
                GameObject popupEintrag = Instantiate(this.popupEintragPrefab);
                popupEintrag.GetComponent<PopupEintragController>().InitPopupEintragController(eintrag);
            }
        }
    }
}

