using System;
using Lifehack.Model.Enum;

namespace Lifehack.Model.Stadtplan {

    public class Umwelt : DatenbankEintrag {

        private bool begehbar;
        public bool Begehbar {
            get { return begehbar; }
            set { this.begehbar = value; }
        }

        public override Kartenelement_art Tabelle<Kartenelement_art>() {
            return Kartenelement_art.UMWELT;
        }
    }
}

