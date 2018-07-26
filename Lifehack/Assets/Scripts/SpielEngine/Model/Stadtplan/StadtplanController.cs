
using System.Collections.Generic;
using Lifehack.Model.Stadtplan;
using UnityEngine;
using SimpleJSON;
using System;

namespace Lifehack.SpielEngine.Model.Stadtplan {

    public class StadtplanController : MonoBehaviour {

        private static StadtplanController _instance;
        public static StadtplanController Instance {
            get { return StadtplanController._instance; }
        }

        private void Start() {
            StadtplanController._instance = this;
        }

        private Dictionary<string, Abmessung> abmessungen = new Dictionary<string, Abmessung>();
        private int kachelGroesse;
        public int KachelGroesse {
            get { return this.kachelGroesse; }
            set { this.kachelGroesse = value; }
        }

        public void InitStadtplan(JSONNode jsonKarte) {
            foreach(string identifier in jsonKarte.Keys) {
                Abmessung abmessung = SimpleAbmessungFabrik.ErzeugeAbmessung();
                foreach (JSONNode feld in jsonKarte[identifier].Children) {
                    string[] werte = feld.Value.Split('/');
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

