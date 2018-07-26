
using Lifehack.Model.Konstanten;

namespace Lifehack.Model.Prozess {

    public class Teilaufgabe : DatenbankEintrag {

        private Item bedingung;
        public Item Bedingung {
            get { return this.bedingung; }
            set { this.bedingung = value; }
        }
        private Item belohnung;
        public Item Belohnung {
            get { return this.belohnung; }
            set { this.belohnung = value; }
        }
        private TeilaufgabeArt teilaufgabeArt;
        public TeilaufgabeArt TeilaufgabeArt {
            get { return this.teilaufgabeArt; }
            set { this.teilaufgabeArt = value; }
        }
        private Dialog dialog;
        public Dialog Dialog {
            get { return this.dialog; }
            set { this.dialog = value; }
        }
        private InstitutArt institutArt;
        public InstitutArt InstitutArt {
            get { return this.institutArt; }
            set { this.institutArt = value; }
        }

        public Teilaufgabe() : base() { }

        public override TabellenName Tabelle() {
            return TabellenName.TEILAUFGABE;
        }

        public override string ToString() {
            return "TEILAUFGABE: id:" + this.Id + "; teilaufgabeArt: " + this.teilaufgabeArt.ToString() + "; institutArt: " + this.institutArt.ToString() + "; dialog: " + this.dialog.ToString() + "; Bedingung: " + this.bedingung.ToString() + "; Belohnung: " + this.belohnung + "; ";
        }
    }
}
