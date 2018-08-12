
using UnityEngine;
using UnityEngine.UI;
using Lifehack.Anwendung.Spiel.Popup;
using System;
using System.Collections.Generic;
using Lifehack.Model.Prozess;
using Lifehack.Model.Einrichtung;
using Lifehack.Model.Stadtplan;
using Lifehack.Anwendung.Spiel.Popup.PopupEintrag.Model.Einrichtung;
using Lifehack.Anwendung.Spiel.Popup.PopupEintrag.Model.Prozess;
using Lifehack.Model;
using Lifehack.Anwendung.Spiel.Popup.PopupEintrag;
using Lifehack.Model.Konstanten;
using Lifehack.Anwendung.Spiel.Form;
using System.Collections;

namespace Lifehack.Anwendung.Spiel.Popup {

    public class PopupModul : Modul<IDatenbankEintrag, IDatenbankEintrag> {

        public GameObject content, popupTitel;

        public GameObject popupEintragPrefab;


        static PopupModul _instance;
        public static PopupModul Instance {
            get { return PopupModul._instance; }
        }

        const int gesamtPlatz = 440;
        const int zwischenRaum = 30;

        void Start() {
            PopupModul._instance = this;
            StartCoroutine(this.WarteAufFormModul());
        }

        private IEnumerator WarteAufFormModul(){
            while (FormModul.Instance == null) {
                yield return new WaitForSeconds(0.01f);
            }
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

        protected override GameObject ErzeugeEintragAdapter(IDatenbankEintrag eintrag) {
            var popupEintrag = Instantiate(this.popupEintragPrefab);
            this.ErzeugePopupButton(popupEintrag, eintrag);
            return this.SetzeButtonText(popupEintrag);
        }

        void ErzeugePopupButton(GameObject popupEintrag, IDatenbankEintrag eintrag) {
            var popupButton = popupEintrag.transform.GetChild(0).gameObject;
            if (typeof(Aufgabe).IsAssignableFrom(eintrag.GetType())) {
                popupButton.AddComponent<AufgabePopupEintragAdapter>();
                popupButton.GetComponent<AufgabePopupEintragAdapter>().Eintrag = (Aufgabe)eintrag;
            } else if (typeof(Item).IsAssignableFrom(eintrag.GetType())) {
                popupButton.AddComponent<ItemPopupEintragAdapter>();
                popupButton.GetComponent<ItemPopupEintragAdapter>().Eintrag = (Item)eintrag;
            } else if (typeof(Institut).IsAssignableFrom(eintrag.GetType())) {
                popupButton.AddComponent<InstitutPopupEintragAdapter>();
                popupButton.GetComponent<InstitutPopupEintragAdapter>().Eintrag = (Institut)eintrag;
            } else if (typeof(Kartenelement).IsAssignableFrom(eintrag.GetType())) {
                popupButton.AddComponent<KartenelementPopupEintragAdapter>();
                popupButton.GetComponent<KartenelementPopupEintragAdapter>().Eintrag = (Kartenelement)eintrag;
                GameObject popupInfo = this.ErzeugeInfoEintrag(eintrag.ToString());
                popupInfo.transform.SetParent(popupEintrag.transform);
            }
        }

        GameObject SetzeButtonText(GameObject popupEintrag) {
            var popupButton = popupEintrag.transform.GetChild(0).gameObject;
            popupButton.GetComponentInChildren<Text>().text = popupButton.GetComponent<IPopupEintrag>().GetEintragInhalt();
            return popupEintrag;
        }
    }
}

