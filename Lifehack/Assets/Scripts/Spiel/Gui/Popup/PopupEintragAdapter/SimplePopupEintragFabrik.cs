
using Lifehack.Model;
using Lifehack.Model.Prozess;
using Lifehack.Model.Einrichtung;
using UnityEngine;
using Lifehack.Model.Stadtplan;
using Lifehack.Spiel.Gui.Popup.PopupEintragAdapter.Model.Prozess;
using Lifehack.Spiel.Gui.Popup.PopupEintragAdapter.Model.Einrichtung;
using UnityEngine.UI;
using Lifehack.Model.Konstanten;

namespace Lifehack.Spiel.Gui.Popup.PopupEintragAdapter {

    public class SimplePopupEintragFabrik : MonoBehaviour {

        public GameObject
        popupEintragPrefab,
        infoPrefab;

        public GameObject ErzeugePopupEintrag(IDatenbankEintrag datenbankEintrag) {
            var popupEintrag = Instantiate(this.popupEintragPrefab);
            this.ErzeugePopupButton(popupEintrag, datenbankEintrag);
            return this.SetzeButtonText(popupEintrag);
        }

        public GameObject ErzeugeAuswahlEintrag(TabellenName tabellenName) {
            var popupEintrag = Instantiate(this.popupEintragPrefab);
            this.ErzeugeAuswahlButton(popupEintrag, tabellenName);
            return this.SetzeButtonText(popupEintrag);
        }

        public GameObject ErzeugeInfoEintrag(string erklaerung) {
            var popupInfo = Instantiate(this.infoPrefab);
            popupInfo.GetComponentInChildren<Text>().text = erklaerung;
            return popupInfo;
        }

        void ErzeugeAuswahlButton(GameObject popupEintrag, TabellenName tabellenName) {
            GameObject popupButton = popupEintrag.transform.GetChild(0).gameObject;
            popupButton.AddComponent<AuswahlPopupEintragAdapter>();
            popupButton.GetComponent<AuswahlPopupEintragAdapter>().Eintrag = tabellenName;
        }
        void ErzeugePopupButton(GameObject popupEintrag, IDatenbankEintrag datenbankEintrag) {
            var popupButton = popupEintrag.transform.GetChild(0).gameObject;
            if (typeof(Aufgabe).IsAssignableFrom(datenbankEintrag.GetType())) {
                popupButton.AddComponent<AufgabePopupEintragAdapter>();
                popupButton.GetComponent<AufgabePopupEintragAdapter>().Eintrag = (Aufgabe)datenbankEintrag;
            } else if (typeof(Item).IsAssignableFrom(datenbankEintrag.GetType())) {
                popupButton.AddComponent<ItemPopupEintragAdapter>();
                popupButton.GetComponent<ItemPopupEintragAdapter>().Eintrag = (Item)datenbankEintrag;
            } else if (typeof(Institut).IsAssignableFrom(datenbankEintrag.GetType())) {
                popupButton.AddComponent<InstitutPopupEintragAdapter>();
                popupButton.GetComponent<InstitutPopupEintragAdapter>().Eintrag = (Institut)datenbankEintrag;
            } else if (typeof(Kartenelement).IsAssignableFrom(datenbankEintrag.GetType())) {
                popupButton.AddComponent<KartenelementPopupEintragAdapter>();
                popupButton.GetComponent<KartenelementPopupEintragAdapter>().Eintrag = (Kartenelement)datenbankEintrag;
                GameObject popupInfo = this.ErzeugeInfoEintrag(datenbankEintrag.ToString());
                popupInfo.transform.SetParent(popupEintrag.transform);
            }
        }

        GameObject SetzeButtonText(GameObject popupEintrag) {
            var popupButton = popupEintrag.transform.GetChild(0).gameObject;
            popupButton.GetComponentInChildren<Text>().text = popupButton.GetComponent<IPopupEintrag>().GetPopupEintragText();
            return popupEintrag;
        }
    }
}

