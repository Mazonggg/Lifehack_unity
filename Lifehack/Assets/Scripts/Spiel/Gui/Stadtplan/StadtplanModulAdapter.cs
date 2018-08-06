
using System.Collections.Generic;
using Lifehack.Model.Stadtplan;
using SimpleJSON;
using System;
using Lifehack.Model;
using Lifehack.Spiel.Gui.Stadtplan.KachelAdapter;
using Lifehack.Austauschformat;
using UnityEngine;
using Lifehack.Spiel.Gui.Popup.PopupEintragAdapter;
using Lifehack.Spiel.Gui.Popup;
using Lifehack.Spiel.Gui.Steuerung;

namespace Lifehack.Spiel.Gui.Stadtplan {

    public class StadtplanModulAdapter : ModulAdapter<IKartenelement> {

        static StadtplanModulAdapter _instance;
        public static StadtplanModulAdapter Instance {
            get { return StadtplanModulAdapter._instance; }
        }

        void Start() {
            StadtplanModulAdapter._instance = this;

            JSONNode json = AustauschAbrufer.Instance.Json;

            this.SetKonfiguration(json[AustauschKonstanten.KONFIGURATION]);
            this.SammleAbmessungen(json[AustauschKonstanten.KARTE]);
            this.PlatziereKacheln(ModelHandler.Instance.Kartenelemente);
        }

        Dictionary<string, Abmessung> abmessungen = new Dictionary<string, Abmessung>();
        int kachelGroesse;
        public int KachelGroesse {
            get { return this.kachelGroesse; }
        }

        public Abmessung GetAbmessung(string identifier) {
            return this.abmessungen[identifier];
        }

        public override void LeereInhalt() {
            return;
        }

        void SetKonfiguration(JSONNode jsonKonfiguration) {
            Int32.TryParse(jsonKonfiguration[AustauschKonstanten.KACHEL_GROESSE].Value, out this.kachelGroesse);
        }

        void SammleAbmessungen(JSONNode jsonKarte) {
            foreach (string identifier in jsonKarte.Keys) {
                var abmessung = SimpleAbmessungFabrik.ErzeugeAbmessung(jsonKarte, identifier);
                this.abmessungen.Add(identifier, abmessung);
            }
        }

        void PlatziereKacheln(Dictionary<string, Kartenelement> kartenelemente) {
            foreach (string kartenelementIdentifier in kartenelemente.Keys) {
                GetComponent<SimpleKachelFabrik>().ErzeugeKachel(kartenelemente[kartenelementIdentifier]);
            }
        }

        public override void GetInhalt(IKartenelement inhalt) {
            if (SteuerungModulAdapter.Instance.gameObject.activeInHierarchy) {
                SteuerungModulAdapter.Instance.SchliesseModul();
                PopupModulAdapter.Instance.GetInhalt(new GameObject[] { PopupModulAdapter.Instance.GetComponent<SimplePopupEintragFabrik>().ErzeugePopupEintrag(inhalt) }, this);
            }
        }

        public override string GetPopupTitel() {
            return "StadtplanModul";
        }
    }
}

