using System;
using Lifehack.Model.Enum;

namespace Lifehack.Model.Stadtplan {
    
    public class Wohnhaus : Gebaeude {

        private int wohneinheiten;
        public int Wohneinheiten {
            get { return wohneinheiten; }
        }

        public Wohnhaus(int id, string kartenelementAussehen, string interieurAussehen, int wohneinheiten) 
            : base(id, kartenelementAussehen, interieurAussehen) {
            this.wohneinheiten = wohneinheiten;
        }

        public override TabellenName Tabelle() {
            return TabellenName.WOHNHAUS;
        }
    }
}

