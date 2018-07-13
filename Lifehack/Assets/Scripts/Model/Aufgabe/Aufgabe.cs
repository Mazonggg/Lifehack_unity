using System;
using System.Collections.Generic;
using Lifehack.Model.Enum;

namespace Lifehack.Model.Aufgabe {
    
    public class Aufgabe : DatenbankEintrag {

        private string bezeichnung;
        public string Bezeichnung {
            get { return this.bezeichnung; }
        }
        private string gesetzesgrundlade;
        public string Gesetzesgrundlage {
            get { return this.gesetzesgrundlade; }
        }
        private List<Teilaufgabe> teilaufgaben;
        public List<Teilaufgabe> Teilaufgaben {
            get { return teilaufgaben; }
        }

        public Aufgabe(int id, string bezeichnung, string gesetzesgrundlade, List<Teilaufgabe> teilaufgaben) 
            : base(id) {
            this.bezeichnung = bezeichnung;
            this.gesetzesgrundlade = gesetzesgrundlade;
            this.teilaufgaben = teilaufgaben;
        }

        public override TabellenName Tabelle() {
            return TabellenName.AUFGABE;
        }
    }
}
