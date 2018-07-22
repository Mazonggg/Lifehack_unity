using System;
using System.Collections.Generic;
using Lifehack.Model.Enum;
using UnityEngine;

namespace Lifehack.Model.Stadtplan {

    public class Abmessung : DatenbankEintrag {

        private List<Rect> felder = new List<Rect>();

        public Abmessung() { }

        public void AddFeld(Rect feld) {
            this.felder.Add(feld);
        }

        /*public int XMin {
            get { return this.x; }
        }
        public int YMin {
            get { return this.y; }
        }
        public int Breite {
            get { return this.breite; }
        }
        public int Hoehe {
            get { return this.hoehe; }
        }
        public int XMax {
            get { return this.x + this.breite; }
        }
        public int YMax {
            get { return this.y + this.hoehe; }
        }*/

        public override TabellenName Tabelle() {
            return TabellenName.ABMESSUNG;
        }
    }
}

