using System;
using Lifehack.Model.Konstanten;

namespace Lifehack.Model.Stadtplan {

    public class Umwelt : Kartenelement {

         bool begehbar;
        public bool Begehbar {
            get { return begehbar; }
            set { this.begehbar = value; }
        }

        public override KartenelementArt KartenelementArt {
            get { return KartenelementArt.UMWELT; }
        }

        public override TabellenName Tabelle() {
            return TabellenName.UMWELT;
        }
    }
}

