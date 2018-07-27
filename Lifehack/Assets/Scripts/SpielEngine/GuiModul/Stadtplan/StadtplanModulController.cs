
using System.Collections.Generic;
using Lifehack.Model.Stadtplan;
using UnityEngine;
using SimpleJSON;
using System;
using Lifehack.Model;

namespace Lifehack.Spielengine.GuiModul.Stadtplan {

    public class StadtplanModulController : MonoBehaviour {

        private static StadtplanModulController _instance;
        public static StadtplanModulController Instance {
            get { return StadtplanModulController._instance; }
        }

        private void Start() {
            StadtplanModulController._instance = this;
        }

        private Dictionary<string, Abmessung> abmessungen = new Dictionary<string, Abmessung>();
        private int kachelGroesse;
        public int KachelGroesse {
            get { return this.kachelGroesse; }
        }

        public void InitStadtplan(JSONNode jsonKarte, int kachelGroesse) {
            this.kachelGroesse = kachelGroesse;
            foreach (string identifier in jsonKarte.Keys) {
                Abmessung abmessung = SimpleAbmessungFabrik.ErzeugeAbmessung();
                foreach (JSONNode feld in jsonKarte[identifier].Children) {
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
                KartenelementControllerGenerator.Instance.ErzeugeKartenelementObjekt(kartenelemente[kartenelementIdentifier]);
            }
        }
        public Abmessung GetAbmessung(string identifier) {
            return this.abmessungen[identifier];
        }
    }
}

