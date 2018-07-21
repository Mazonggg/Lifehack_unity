using System;
using Lifehack.Model.Enum;

namespace Lifehack.Model.Stadtplan {

    public class Abmessung : DatenbankEintrag {

        private readonly int x, y, breite, hoehe;
        private readonly string identifier;

        public Abmessung(int x, int y, int breite, int hoehe, string identifier) {
            this.x = x;
            this.y = y;
            this.breite = breite;
            this.hoehe = hoehe;
            this.identifier = identifier;
        }

        public int XMin {
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
        }

        public override TabellenName Tabelle() {
            return TabellenName.ABMESSUNG;
        }
    }
}

