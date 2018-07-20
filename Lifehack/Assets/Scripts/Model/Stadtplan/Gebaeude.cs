using System;
using Lifehack.Model.Enum;

namespace Lifehack.Model.Stadtplan {

    public class Gebaeude : Kartenelement {

        private string interieurAussehen;
        public string InterieurAussehen {
            get { return interieurAussehen; }
            set { this.interieurAussehen = value; }
        }

        public override KartenelementArt KartenelementArt {
            get { return KartenelementArt.GEBAEUDE; }
        }

        public Gebaeude() : base() { }

        public override TabellenName Tabelle() {
            return TabellenName.GEBAEUDE;
        }
    }
}
