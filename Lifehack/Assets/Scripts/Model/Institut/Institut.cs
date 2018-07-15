using System;
using System.Collections.Generic;
using Lifehack.Model.Enum;

namespace Lifehack.Model.Institut {

    public class Institut : DatenbankEintrag {

        private List<Niederlassung> niederlassungen;
        public List<Niederlassung> Niederlassungen {
            get { return this.niederlassungen; }
            set { this.niederlassungen = value; }
        }
        private string name;
        public string Name {
            get { return this.name; }
            set { this.name = value; }
        }
        private string beschreibung;
        public string Beschreibung {
            get { return this.beschreibung; }
            set { this.beschreibung = value; }
        }
        private string institut_art;
        public string Institut_art {
            get { return this.institut_art; }
            set { this.institut_art = value; }
        }

        public override TabellenName Tabelle<TabellenName>() {
            return TabellenName.INSTITUT;
        }
    }
}
