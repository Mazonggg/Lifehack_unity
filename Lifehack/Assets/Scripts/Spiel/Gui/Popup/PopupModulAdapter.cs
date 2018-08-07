
using UnityEngine;
using UnityEngine.UI;
using Lifehack.Spiel.Gui.Popup;
using System;
using System.Collections.Generic;
using Lifehack.Model.Prozess;
using Lifehack.Model.Einrichtung;
using Lifehack.Model.Stadtplan;
using Lifehack.Spiel.Gui.Popup.PopupEintrag.Model.Einrichtung;
using Lifehack.Spiel.Gui.Popup.PopupEintrag.Model.Prozess;
using Lifehack.Model;
using Lifehack.Spiel.Gui.Popup.PopupEintrag;
using Lifehack.Model.Konstanten;

namespace Lifehack.Spiel.Gui.Popup {

    public class PopupModulAdapter : ModulAdapter<IDatenbankEintrag, IDatenbankEintrag> {

        public GameObject content, popupTitel;

        public GameObject popupEintragPrefab;


        static PopupModulAdapter _instance;
        public static PopupModulAdapter Instance {
            get { return PopupModulAdapter._instance; }
        }

        const int gesamtPlatz = 440;
        const int zwischenRaum = 30;

        void Start() {
            PopupModulAdapter._instance = this;
            gameObject.SetActive(false);
        }

        public override void LeereInhalt() {
            this.popupTitel.GetComponent<Text>().text = "";
            foreach (Transform child in this.content.transform) {
                Destroy(child.gameObject);
            }
        }

        public void SetzeTitel(string titel) {
            this.popupTitel.GetComponent<Text>().text = titel;
        }

        public void SetInhalt(List<GameObject> eintraege, IPopupTitelgeber titelgeber) {
            if (titelgeber != null) {
                this.SetzeTitel(titelgeber.GetPopupTitel());
            }
            this.content.transform.DetachChildren();
            for (int i = 0; i < eintraege.Count; i++) {
                eintraege[i].transform.SetParent(this.content.transform);
            }
            this.OeffneModul();
        }

        public override void GetInhalt(List<IDatenbankEintrag> eintraege) {
            if (eintraege.Count > 0) {
                this.SetInhalt(this.ErzeugeEintragAdapters(eintraege), null);
                this.SetzeTitel(StringHelfer.Ucfirst(EnumHandler.AlsString(eintraege[0].Tabelle())));
            }
        }

        public override string GetPopupTitel() {
            return "";
        }

        protected override GameObject ErzeugeEintragAdapter(IDatenbankEintrag datenbankEintrag) {
            var popupEintrag = Instantiate(this.popupEintragPrefab);
            this.ErzeugePopupButton(popupEintrag, datenbankEintrag);
            return this.SetzeButtonText(popupEintrag);
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
            popupButton.GetComponentInChildren<Text>().text = popupButton.GetComponent<IPopupEintrag>().GetEintragText();
            return popupEintrag;
        }
    }
}

