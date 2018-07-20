using System;
using Lifehack.Model.Enum;

namespace Lifehack.Model.Stadtplan {

    public class Umwelt : Kartenelement {

        private bool begehbar;
        public bool Begehbar {
            get { return begehbar; }
            set { this.begehbar = value; }
        }

        public override KartenelementArt KartenelementArt {
            get { return KartenelementArt.UMWELT; }
        }

        public Umwelt(bool begehbar) : base() {
            this.begehbar = begehbar;
        }

        public override TabellenName Tabelle() {
            return TabellenName.UMWELT;
        }
    }
}

