
using System.Collections.Generic;
using Lifehack.Model.Konstanten;

namespace Lifehack.Model.Prozess {

    public class Aufgabe : DatenbankEintrag {

        string bezeichnung;
        public string Bezeichnung {
            get { return this.bezeichnung; }
            set { this.bezeichnung = value; }
        }
        string gesetzesgrundlage;
        public string Gesetzesgrundlage {
            get { return this.gesetzesgrundlage; }
            set { this.gesetzesgrundlage = value; }
        }
        Teilaufgabe[] teilaufgaben = new Teilaufgabe[] { };
        public Teilaufgabe[] Teilaufgaben {
            get { return teilaufgaben; }
            set { this.teilaufgaben = value; }
        }

        Status status = Status.OFFEN;
        public Status Status {
            get { return this.status; }
            set { this.status = value; }
        }

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
