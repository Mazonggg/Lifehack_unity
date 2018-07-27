using System;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;

namespace Lifehack.Model.Stadtplan {

    public class SimpleAbmessungFabrik {

        public static Abmessung ErzeugeAbmessung(JSONNode jsonKarte, string identifier) {
            Abmessung abmessung = new Abmessung();
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
            return abmessung;
        }
    }
}

