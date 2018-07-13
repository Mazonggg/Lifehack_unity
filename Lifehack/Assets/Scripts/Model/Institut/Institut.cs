using System;
using System.Collections.Generic;
using Lifehack.Model.Enum;

namespace Lifehack.Model.Institut {
    
    public class Institut : DatenbankEintrag {

        private List<Niederlassung> niederlassungen;
        private string name;
        private string beschreibung;
        private string institut_art;

        public Institut(int id, List<Niederlassung> niederlassungen, string name, string beschreibung, string institut_art) : base(id) {
            this.niederlassungen = niederlassungen;
            this.name = name;
            this.beschreibung = beschreibung;
            this.institut_art = institut_art;
        }

        public override TabellenName Tabelle() {
            return TabellenName.INSTITUT;
        }
    }
}
