using System;
using System.Collections.Generic;

namespace Lifehack.Model.Stadtplan {
    
    public class SimpleAbmessungFabrik {

        public const char POSITIONS_EINTRAG_TRENNER = ',';
        public const char POSITIONS_TRENNER = '/';

        public static List<Abmessung> erzeugeAbmessungen(string abmessungsDaten, string identifier) {
            List<Abmessung> abmessungen = new List<Abmessung>();
            foreach (string abmessungDaten in abmessungsDaten.Split(POSITIONS_EINTRAG_TRENNER)) {
                abmessungen.Add(SimpleAbmessungFabrik.ErzeugeAbmessung(abmessungDaten, identifier));
            }
            return abmessungen;
        }

        public static Abmessung ErzeugeAbmessung(string abmessungDaten, string identifier){
            string[] daten = abmessungDaten.Split(POSITIONS_TRENNER);
            int x = 0;
            Int32.TryParse(daten[0], out x);
            int y = 0;
            Int32.TryParse(daten[1], out x);
            int breite = 0;
            Int32.TryParse(daten[2], out x);
            int heohe = 0;
            Int32.TryParse(daten[3], out x);
            return new Abmessung(x, breite, y, heohe, identifier);
        }
    }
}

