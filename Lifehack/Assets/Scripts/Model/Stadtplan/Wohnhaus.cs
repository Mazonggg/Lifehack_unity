using System;
using Lifehack.Model.Konstanten;

namespace Lifehack.Model.Stadtplan {

    public class Wohnhaus : Gebaeude {

        int wohneinheiten;
        public int Wohneinheiten {
            get { return wohneinheiten; }
            set { this.wohneinheiten = value; }
        }

        public override KartenelementArt KartenelementArt {
            get { return KartenelementArt.WOHNHAUS; }
        }

        public override TabellenName Tabelle() {
            return TabellenName.WOHNHAUS;
        }

        public override string ToString() {
            if (this.wohneinheiten > 0) {
                return "Hier sind noch " + this.wohneinheiten + " Wohneinheiten verfügbar.";
            } else {
                return "Hier ist kein freier Wohnraum mehr verfügbar.";
            }
        }
    }
}

