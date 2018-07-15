using System;
using Lifehack.Model.Enum;
using Lifehack.Model.Stadtplan;

namespace Lifehack.Model.Institut {

    public class Niederlassung : Gebaeude {

        private Institut institut;
        public Institut Institut {
            get { return institut; }
            set { this.institut = value; }
        }

        public override Kartenelement_art Tabelle<Kartenelement_art>() {
            return Kartenelement_art.NIEDERLASSUNG;
        }
    }
}
