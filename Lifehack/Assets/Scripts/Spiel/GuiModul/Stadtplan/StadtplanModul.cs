
using System.Collections.Generic;
using Lifehack.Model.Stadtplan;
using UnityEngine;
using SimpleJSON;
using System;
using Lifehack.Model;
using Lifehack.Spiel.GuiModul.Stadtplan.StadtplanController;
using Lifehack.Austauschformat;

namespace Lifehack.Spiel.GuiModul.Stadtplan {

    public class StadtplanModul : SpielModul {

        private static StadtplanModul _instance;
        public static StadtplanModul Instance {
            get { return StadtplanModul._instance; }
        }

        protected new void Start() {
            StadtplanModul._instance = this;
        }

        private Dictionary<string, Abmessung> abmessungen = new Dictionary<string, Abmessung>();
        private int kachelGroesse = 0;
        public int KachelGroesse {
            get { return this.kachelGroesse; }
        }

        public Abmessung GetAbmessung(string identifier) {
            return this.abmessungen[identifier];
        }

        protected override void LeereModul() { }

        protected override void BefuelleModul() {
            JSONNode json = AustauschAbrufer.Instance.Json;
            Int32.TryParse(json[AustauschKonstanten.KONFIGURATION][AustauschKonstanten.KACHEL_GROESSE].Value, out this.kachelGroesse);

            foreach (string identifier in json[AustauschKonstanten.KARTE].Keys) {
                Abmessung abmessung = SimpleAbmessungFabrik.ErzeugeAbmessung();
                foreach (JSONNode feld in json[AustauschKonstanten.KARTE][identifier].Children) {
                    string[] werte = feld.Value.Split(AustauschKonstanten.ABMESSUNG_TRENNER);
                    float x = 0;
                    float.TryParse(werte[0], out x);
                    float y = 0;
                    float.TryParse(werte[1], out y);
                    float breite = 0;
                    float.TryParse(werte[2], out breite);
                    float hoehe = 0;
                    float.TryParse(werte[3], out hoehe);
                    abmessung.AddFeld(new Rect(x, -y, breite, hoehe));
                }
                this.abmessungen.Add(identifier, abmessung);
            }

            Dictionary<string, Kartenelement> kartenelemente = ModelHandler.Instance.Kartenelemente;
            foreach (string kartenelementIdentifier in kartenelemente.Keys) {
                KartenelementControllerFabrik.Instance.ErzeugeKartenelementObjekt(kartenelemente[kartenelementIdentifier]);
            }
        }
    }
}

