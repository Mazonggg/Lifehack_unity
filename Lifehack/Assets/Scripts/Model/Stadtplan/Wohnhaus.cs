using System;
using Lifehack.Model.Enum;

namespace Lifehack.Model.Stadtplan {

    public class Wohnhaus : Gebaeude {

        private int wohneinheiten;
        public int Wohneinheiten {
            get { return wohneinheiten; }
            set { this.wohneinheiten = value; }
        }

        public override Kartenelement_art Tabelle<Kartenelement_art>() {
            return Kartenelement_art.WOHNHAUS;
        }
    }
}

