using System;
using Lifehack.Model.Konstanten;

namespace Lifehack.Model.Stadtplan {

    public class Gebaeude : Kartenelement {

        string interieurAussehen;
        public string InterieurAussehen {
            get { return interieurAussehen; }
            set { this.interieurAussehen = value; }
        }

        public override KartenelementArt KartenelementArt {
            get { return KartenelementArt.GEBAEUDE; }
        }

        public override TabellenName Tabelle() {
            return TabellenName.GEBAEUDE;
        }
    }
}
