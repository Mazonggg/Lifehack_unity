
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
            //this.InitKartenAbmessungen(jsonKarte);
            Dictionary<string, Kartenelement> kartenelemente = ModelHandler.Instance.Kartenelemente;
            foreach (string kartenelementIdentifier in kartenelemente.Keys) {
                KartenelementControllerGenerator.Instance.ErzeugeKartenelementObjekt(kartenelemente[kartenelementIdentifier]);
            }
        }

        /* private void InitKartenAbmessungen(JSONNode jsonKarte) {
             ModelHandler.Log(jsonKarte.ToString());
             Dictionary<string, Abmessung> werte = new Dictionary<string, Abmessung>()
             foreach (string yWert in jsonKarte.Keys) {
                 int xMin = 0;
                 Int32.TryParse(jsonKarte[yWert][0].Value, out xMin);
                 for (int xWert = xMin; xWert < jsonKarte[yWert].Count; xWert++) {
                     if (!jsonKarte[yWert][xWert].Value.Equals(" ")) {
                         if (werte.ContainsKey(jsonKarte[yWert][xWert].Value)) {
                             werte[identifier].AddFeld(this.SammpleFeld(xWert, yWert, jsonKarte));
                         } else {
                             Abmessung abmessung = SimpleAbmessungFabrik.ErzeugeAbmessung();
                             abmessung.AddFeld(this.SammpleFeld(xWert, yWert, jsonKarte));
                             werte[identifier] = abmessung;
                         }
                     }
                 }
                 ModelHandler.Log("yWert: " + yWert);
             }
         }

         private Abmessung SammpleFeld(int xWert, int yWert, JSONNode jsonKarte) {
             int breite = 1;
             int hoehe = 1;
             while()
         }*/
    }
}

