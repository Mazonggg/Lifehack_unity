
using Lifehack.Model.Konstanten;

namespace Lifehack.Model.Prozess {

    public class Teilaufgabe : DatenbankEintrag {

        Item bedingung;
        public Item Bedingung {
            get { return this.bedingung; }
            set { this.bedingung = value; }
        }
        Item belohnung;
        public Item Belohnung {
            get { return this.belohnung; }
            set { this.belohnung = value; }
        }
        TeilaufgabeArt teilaufgabeArt;
        public TeilaufgabeArt TeilaufgabeArt {
            get { return this.teilaufgabeArt; }
            set { this.teilaufgabeArt = value; }
        }
        Dialog dialog;
        public Dialog Dialog {
            get { return this.dialog; }
            set { this.dialog = value; }
        }
        InstitutArt institutArt;
        public InstitutArt InstitutArt {
            get { return this.institutArt; }
            set { this.institutArt = value; }
        }

        bool abgeschlossen;
        public bool Abgeschlossen {
            get { return this.abgeschlossen; }
            set { this.abgeschlossen = value; }
        }

        public override TabellenName Tabelle() {
            return TabellenName.TEILAUFGABE;
        }

        public override string ToString() {
            return "TEILAUFGABE: id:" + this.Id + "; teilaufgabeArt: " + this.teilaufgabeArt + "; institutArt: " + this.institutArt + "; dialog: " + this.dialog + "; Bedingung: " + this.bedingung + "; Belohnung: " + this.belohnung + "; ";
        }
    }
}
