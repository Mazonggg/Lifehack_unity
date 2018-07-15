using System.Collections.Generic;
using Lifehack.Model.Enum;

namespace Lifehack.Model.Aufgabe {

    public class Aufgabe : DatenbankEintrag {

        private string bezeichnung;
        public string Bezeichnung {
            get { return this.bezeichnung; }
            set { this.bezeichnung = value; }
        }
        private string gesetzesgrundlage;
        public string Gesetzesgrundlage {
            get { return this.gesetzesgrundlage; }
            set { this.gesetzesgrundlage = value; }
        }
        private List<Teilaufgabe> teilaufgaben;
        public List<Teilaufgabe> Teilaufgaben {
            get { return teilaufgaben; }
            set { this.teilaufgaben = value; }
        }

        public override Kartenelement_art Tabelle<Kartenelement_art>() {
            return Kartenelement_art.AUFGABE;
        }
    }
}
