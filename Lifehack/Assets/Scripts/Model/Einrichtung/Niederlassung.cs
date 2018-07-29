using System;
using Lifehack.Model.Konstanten;
using Lifehack.Model.Stadtplan;

namespace Lifehack.Model.Einrichtung {

    public class Niederlassung : Gebaeude {

        Institut institut;
        public Institut Institut {
            get { return institut; }
            set { this.institut = value; }
        }

        public override KartenelementArt KartenelementArt {
            get { return KartenelementArt.NIEDERLASSUNG; }
        }

        public override TabellenName Tabelle() {
            return TabellenName.NIEDERLASSUNG;
        }
    }
}

