
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

        public void InitStadtplan(JSONNode jsonKarte) {
            this.InitKartenAbmessungen(jsonKarte);
            Dictionary<string, Kartenelement> kartenelemente = ModelHandler.Instance.Kartenelemente;
            foreach (string kartenelementIdentifier in kartenelemente.Keys) {
                KartenelementControllerGenerator.Instance.ErzeugeKartenelementObjekt(kartenelemente[kartenelementIdentifier]);
            }
        }
        public Abmessung GetAbmessung(string identifier) {
            return this.abmessungen[identifier];
        }

        private void InitKartenAbmessungen(JSONNode jsonKarte) {
            Dictionary<string, Abmessung> werte = new Dictionary<string, Abmessung>();
            foreach (string yWert in jsonKarte.Keys) {
                int xMin = this.GetXMin(jsonKarte[yWert]);
                for (int xWert = xMin; xWert < jsonKarte[yWert].Count; xWert++) {
                    string identifier = jsonKarte[yWert][xWert.ToString()].Value;
                    if (this.IstNeuesFeld(identifier)) {
                        if (werte.ContainsKey(identifier)) {
                            werte[identifier].AddFeld(this.SammleFeld(xWert.ToString(), yWert, jsonKarte));
                        } else {
                            Abmessung abmessung = SimpleAbmessungFabrik.ErzeugeAbmessung();
                            abmessung.AddFeld(this.SammleFeld(xWert.ToString(), yWert, jsonKarte));
                            werte[identifier] = abmessung;
                        }
                    }
                }
            }
            this.abmessungen = werte;
        }

        private Rect SammleFeld(string xWert, string yWert, JSONNode jsonKarte) {
            int x = 0;
            Int32.TryParse(xWert, out x);
            int y = 0;
            Int32.TryParse(yWert, out y);
            int breite = 1000;
            int hoehe = 0;
            string identifier = jsonKarte[yWert][xWert].Value;
            do {
                int breiteDieserZeile = 0;
                do {
                    breiteDieserZeile++;
                    x++;
                } while (jsonKarte[(y).ToString()][(x).ToString()].Value.Equals(identifier.ToLower()));
                breite = (breiteDieserZeile < breite ? breiteDieserZeile : breite);
                hoehe++;
                y++;
                Int32.TryParse(xWert, out x);
            } while (jsonKarte[(y).ToString()][(x).ToString()].Value.Equals(identifier.ToLower()));
            Int32.TryParse(yWert, out y);
            return new Rect(new Vector2(x, -y), new Vector2(breite, hoehe));
        }

        private int GetXMin(JSONNode yWert) {
            int xMin = 0;
            foreach (string xString in yWert.Keys) {
                int xWert = 0;
                Int32.TryParse(xString, out xWert);
                xMin = (xWert < xMin ? xWert : xMin);
            }
            return xMin;
        }

        private bool IstNeuesFeld(string identifier) {
            return !identifier.Equals("") && identifier.ToUpper().Equals(identifier);
        }
    }
}

