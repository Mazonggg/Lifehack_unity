
using Lifehack.Model;
using Lifehack.Model.Prozess;
using Lifehack.Model.Einrichtung;
using UnityEngine;
using Lifehack.Model.Stadtplan;
using Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter.Model.Prozess;
using Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter.Model.Einrichtung;
using UnityEngine.UI;
using Lifehack.Model.Konstanten;
using System;

namespace Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter {

    public class PopupEintragFabrik : MonoBehaviour {

        public GameObject
        popupEintragPrefab,
        erklaerungPrefab;

        public GameObject ErzeugePopupEintrag(IDatenbankEintrag datenbankEintrag) {
            GameObject popupEintrag = Instantiate(popupEintragPrefab);
            if (typeof(Aufgabe).IsAssignableFrom(datenbankEintrag.GetType())) {
                popupEintrag.AddComponent<AufgabePopupEintrag>();
                popupEintrag.GetComponent<AufgabePopupEintrag>().Eintrag = (Aufgabe)datenbankEintrag;
            } else if (typeof(Item).IsAssignableFrom(datenbankEintrag.GetType())) {
                popupEintrag.AddComponent<ItemPopupEintrag>();
                popupEintrag.GetComponent<ItemPopupEintrag>().Eintrag = (Item)datenbankEintrag;
            } else if (typeof(Institut).IsAssignableFrom(datenbankEintrag.GetType())) {
                popupEintrag.AddComponent<InstitutPopupEintrag>();
                popupEintrag.GetComponent<InstitutPopupEintrag>().Eintrag = (Institut)datenbankEintrag;
            } else if (typeof(Kartenelement).IsAssignableFrom(datenbankEintrag.GetType())) {
                popupEintrag.AddComponent<KartenelementPopupEintrag>();
                popupEintrag.GetComponent<KartenelementPopupEintrag>().Eintrag = (Kartenelement)datenbankEintrag;
            } else {
                throw new System.Exception();
            }
            return this.SetzeText(popupEintrag);
        }

        public GameObject ErzeugeAuswahlEintrag(TabellenName tabellenName) {
            GameObject popupEintrag;
            popupEintrag = Instantiate(this.popupEintragPrefab);
            popupEintrag.AddComponent<AuswahlPopupEintrag>();
            popupEintrag.GetComponent<AuswahlPopupEintrag>().Eintrag = tabellenName;
            return this.SetzeText(popupEintrag);
        }

        public GameObject ErzeugeErklaerungEintrag(string erklaerung) {
            GameObject popupEintrag;
            popupEintrag = Instantiate(this.erklaerungPrefab);
            popupEintrag.GetComponentInChildren<Text>().text = erklaerung;
            return popupEintrag;
        }

        private GameObject SetzeText(GameObject popupEintrag) {
             popupEintrag.GetComponentInChildren<Text>().text = popupEintrag.GetComponent<IPopupEintragAdapter>().GetPopupEintragText();
            return popupEintrag;
        }
    }
}

