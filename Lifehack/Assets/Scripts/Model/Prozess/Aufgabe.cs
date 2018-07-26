
using System.Collections.Generic;
using Lifehack.Model.Konstanten;

namespace Lifehack.Model.Prozess {

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

        public Aufgabe() : base() { }

        public override TabellenName Tabelle() {
            return TabellenName.AUFGABE;
        }

        public override string ToString() {
            string teilauf = "";
            foreach (Teilaufgabe teilaufgabe in this.teilaufgaben) {
                teilauf += teilaufgabe.ToString();
            }
            return "AUFGABE: id: " + this.Id + "; Bezeichnung: " + this.bezeichnung + "; gesetzesgrundlage: " + this.gesetzesgrundlage + "; teilaufgaben: " + teilauf;
        }
    }
}
