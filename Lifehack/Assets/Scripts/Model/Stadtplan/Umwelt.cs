using System;
using Lifehack.Model.Enum;

namespace Lifehack.Model.Stadtplan {
    
    public class Umwelt : DatenbankEintrag {

        private bool begehbar;
        public bool Begehbar {
            get { return begehbar; }
        }

        public Umwelt(int id, bool begehbar) : base(id) {
            this.begehbar = begehbar;
        }

        public override TabellenName Tabelle() {
            return TabellenName.UMWELT;
        }
    }
}

