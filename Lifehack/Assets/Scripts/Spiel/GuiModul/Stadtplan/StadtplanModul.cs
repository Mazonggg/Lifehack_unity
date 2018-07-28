
using System.Collections.Generic;
using Lifehack.Model.Stadtplan;
using SimpleJSON;
using System;
using Lifehack.Model;
using Lifehack.Spiel.GuiModul.Stadtplan.StadtplanAdapter;
using Lifehack.Austauschformat;
using Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter;

namespace Lifehack.Spiel.GuiModul.Stadtplan {

    public class StadtplanModul : SpielModul {

        private static StadtplanModul _instance;
        public static StadtplanModul Instance {
            get { return StadtplanModul._instance; }
        }

        private void Start() {
            StadtplanModul._instance = this;
            this.GetInhalt();
        }

        private Dictionary<string, Abmessung> abmessungen = new Dictionary<string, Abmessung>();
        private int kachelGroesse;
        public int KachelGroesse {
            get { return this.kachelGroesse; }
        }

        public Abmessung GetAbmessung(string identifier) {
            return this.abmessungen[identifier];
        }

        public override void LeereInhalt() {
            return;
        }

        protected override void GetInhalt() {
            JSONNode json = AustauschAbrufer.Instance.Json;

            this.SetKonfiguration(json[AustauschKonstanten.KONFIGURATION]);
            this.SammleAbmessungen(json[AustauschKonstanten.KARTE]);
            this.PlatziereKacheln(ModelHandler.Instance.Kartenelemente);
        }

        private void SetKonfiguration(JSONNode jsonKonfiguration) {
            Int32.TryParse(jsonKonfiguration[AustauschKonstanten.KACHEL_GROESSE].Value, out this.kachelGroesse);
        }

        private void SammleAbmessungen(JSONNode jsonKarte) {
            foreach (string identifier in jsonKarte.Keys) {
                Abmessung abmessung = SimpleAbmessungFabrik.ErzeugeAbmessung(jsonKarte, identifier);
                this.abmessungen.Add(identifier, abmessung);
            }
        }

        private void PlatziereKacheln(Dictionary<string, Kartenelement> kartenelemente) {
            foreach (string kartenelementIdentifier in kartenelemente.Keys) {
                GetComponent<KachelFabrik>().ErzeugeKachel(kartenelemente[kartenelementIdentifier]);
            }
        }
    }
}

