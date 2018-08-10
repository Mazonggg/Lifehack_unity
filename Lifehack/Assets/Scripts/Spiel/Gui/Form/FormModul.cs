
using System.Collections.Generic;
using Lifehack.Model;
using Lifehack.Model.Einrichtung;
using Lifehack.Model.Prozess;
using Lifehack.Model.Stadtplan;
using Lifehack.Spiel.Gui.Form.FormEintrag.Model.Einrichtung;
using Lifehack.Spiel.Gui.Form.FormEintrag.Model.Prozess;
using Lifehack.Spiel.Gui.Popup;
using UnityEngine;

namespace Lifehack.Spiel.Gui.Form {

    public class FormModul : Modul<IDatenbankEintrag, IDatenbankEintrag> {

        public GameObject content;

        public GameObject
        itemFormPrefab,
        institutFormPrefab,
        aufgabeFormPrefab,
        teilaufgabeFormPrefab,
        niederlassungFormPrefab,
        gebaeudeFormPrefab;

        static FormModul _instance;
        public static FormModul Instance {
            get { return FormModul._instance; }
        }

        void Start() {
            FormModul._instance = this;
            gameObject.SetActive(false);
        }

        public override void LeereInhalt() {
            PopupModul.Instance.LeereInhalt();
        }

        public override void GetInhalt(List<IDatenbankEintrag> eintraege) {
            this.LeereInhalt();
            PopupModul.Instance.SetInhalt(this.ErzeugeEintragAdapters(eintraege), this);
        }

        public override string GetPopupTitel() {
            return "FormModul";
        }

        protected override GameObject ErzeugeEintragAdapter(IDatenbankEintrag eintrag) {
            GameObject form = null;
            if (typeof(Aufgabe).IsAssignableFrom(eintrag.GetType())) {
                form = Instantiate(aufgabeFormPrefab);
                form.GetComponent<AufgabeFormAdapter>().Eintrag = (Aufgabe)eintrag;
            } else if (typeof(Teilaufgabe).IsAssignableFrom(eintrag.GetType())) {
                form = Instantiate(teilaufgabeFormPrefab);
                form.GetComponent<TeilaufgabeFormAdapter>().Eintrag = (Teilaufgabe)eintrag;
            } else if (typeof(Item).IsAssignableFrom(eintrag.GetType())) {
                form = Instantiate(itemFormPrefab);
                form.GetComponent<ItemFormAdapter>().Eintrag = (Item)eintrag;
            } else if (typeof(Institut).IsAssignableFrom(eintrag.GetType())) {
                form = Instantiate(institutFormPrefab);
                form.GetComponent<InstitutFormAdapter>().Eintrag = (Institut)eintrag;
            } else if (typeof(Niederlassung).IsAssignableFrom(eintrag.GetType())) {
                form = Instantiate(niederlassungFormPrefab);
                form.GetComponent<NiederlassungFormAdapter>().Eintrag = (Niederlassung)eintrag;
            } else if (typeof(Gebaeude).IsAssignableFrom(eintrag.GetType())) {
                form = Instantiate(gebaeudeFormPrefab);
            }
            return form;
        }
    }
}

