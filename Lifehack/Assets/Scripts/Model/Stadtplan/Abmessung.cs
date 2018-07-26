using System;
using System.Collections.Generic;
using Lifehack.Model.Konstanten;
using UnityEngine;

namespace Lifehack.Model.Stadtplan {

    public class Abmessung : DatenbankEintrag {

        private List<Rect> felder = new List<Rect>();
        public Rect[] Felder {
            get { return this.felder.ToArray(); }
        }

        public Abmessung() { }

        public void AddFeld(Rect feld) {
            this.felder.Add(feld);
        }

        public override TabellenName Tabelle() {
            return TabellenName.ABMESSUNG;
        }

        public override string ToString() {
            string rects = "";
            foreach (Rect feld in this.felder) {
                rects += "\nx: " + feld.x + "; y" + feld.y + "; breite: " + feld.width + "; hoehe: " + feld.height;
            }
            return "Abmessung: " + rects;
        }
    }
}

