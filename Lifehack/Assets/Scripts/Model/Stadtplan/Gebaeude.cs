using System;
using Lifehack.Model.Enum;

namespace Lifehack.Model.Stadtplan {

    public class Gebaeude : Kartenelement {

        private string interieur_aussehen;
        public string Interieur_aussehen {
            get { return interieur_aussehen; }
            set { this.interieur_aussehen = value; }
        }

        public override Kartenelement_art Tabelle<Kartenelement_art>() {
            return Kartenelement_art.GEBAEUDE;
        }
    }
}
