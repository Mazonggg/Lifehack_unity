using System;
using Lifehack.Model.Enum;
using Lifehack.Model.Stadtplan;

namespace Lifehack.Model.Institut {
    
    public class Niederlassung : Gebaeude {

        private Institut institut;
        public Institut Institut {
            get {  return institut; }
        }

        public Niederlassung(int id, string kartenelementAussehen, string interieurAussehen, Institut institut) 
            : base(id, kartenelementAussehen, interieurAussehen) {
            this.institut = institut;
        }

        public override TabellenName Tabelle() {
            return TabellenName.NIEDERLASSUNG;
        }
    }
}
