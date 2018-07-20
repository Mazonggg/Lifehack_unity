using System;
using Lifehack.Model.Enum;
using Lifehack.Model.Stadtplan;

namespace Lifehack.Model.Einrichtung {

    public class Niederlassung : Gebaeude {

        private Institut institut;
        public Institut Institut {
            get { return institut; }
            set { this.institut = value; }
        }

        public override KartenelementArt KartenelementArt {
            get { return KartenelementArt.NIEDERLASSUNG; }
        }

        public Niederlassung() : base() {
        }

        public override TabellenName Tabelle() {
            return TabellenName.NIEDERLASSUNG;
        }
    }
}
