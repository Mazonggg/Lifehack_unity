
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

    public class FormModulAdapter : ModulAdapter<IDatenbankEintrag, IDatenbankEintrag> {

        public GameObject content;

        public GameObject
        itemFormPrefab,
        institutFormPrefab,
        aufgabeFormPrefab,
        teilaufgabeFormPrefab,
        niederlassungFormPrefab,
        gebaeudeFormPrefab;

        static FormModulAdapter _instance;
        public static FormModulAdapter Instance {
            get { return FormModulAdapter._instance; }
        }

        void Start() {
            FormModulAdapter._instance = this;
            gameObject.SetActive(false);
        }

        public override void LeereInhalt() {
            PopupModulAdapter.Instance.LeereInhalt();
        }

        public override void GetInhalt(List<IDatenbankEintrag> eintraege) {
            this.LeereInhalt();
            PopupModulAdapter.Instance.SetInhalt(this.ErzeugeEintragAdapters(eintraege), this);
        }

        public override string GetPopupTitel() {
            return "FormModul";
        }

        protected override GameObject ErzeugeEintragAdapter(IDatenbankEintrag datenbankEintrag) {
            GameObject form = null;
            if (typeof(Aufgabe).IsAssignableFrom(datenbankEintrag.GetType())) {
                form = Instantiate(aufgabeFormPrefab);
                form.GetComponent<AufgabeFormAdapter>().Eintrag = (Aufgabe)datenbankEintrag;
            } else if (typeof(Teilaufgabe).IsAssignableFrom(datenbankEintrag.GetType())) {
                form = Instantiate(teilaufgabeFormPrefab);
                form.GetComponent<TeilaufgabeFormAdapter>().Eintrag = (Teilaufgabe)datenbankEintrag;
            } else if (typeof(Item).IsAssignableFrom(datenbankEintrag.GetType())) {
                form = Instantiate(itemFormPrefab);
                form.GetComponent<ItemFormAdapter>().Eintrag = (Item)datenbankEintrag;
            } else if (typeof(Institut).IsAssignableFrom(datenbankEintrag.GetType())) {
                form = Instantiate(institutFormPrefab);
                form.GetComponent<InstitutFormAdapter>().Eintrag = (Institut)datenbankEintrag;
            } else if (typeof(Niederlassung).IsAssignableFrom(datenbankEintrag.GetType())) {
                form = Instantiate(niederlassungFormPrefab);
                form.GetComponent<NiederlassungFormAdapter>().Eintrag = (Niederlassung)datenbankEintrag;
            } else if (typeof(Gebaeude).IsAssignableFrom(datenbankEintrag.GetType())) {
                form = Instantiate(gebaeudeFormPrefab);
            }
            return form;
        }
    }
}

