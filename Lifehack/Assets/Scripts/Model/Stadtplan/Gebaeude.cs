using System;
using Lifehack.Model.Enum;

namespace Lifehack.Model.Stadtplan {
    
    public class Gebaeude : Kartenelement {

        private string interieurAussehen;
        public string InterieurAussehen {
            get { return interieurAussehen; }
        }

        public Gebaeude(int id,string kartenelementAussehen, string interieurAussehen)
            : base(id, kartenelementAussehen) {
            this.interieurAussehen = interieurAussehen;
        }

        public override TabellenName Tabelle() {
            return TabellenName.GEBAEUDE;
        }
    }
}
