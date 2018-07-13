using System;
using Lifehack.Model;
using Lifehack.Model.Enum;

namespace Lifehack.Model.Aufgabe {
    
    public class Teilaufgabe : DatenbankEintrag {

        private Item bedingung;
        public Item Bedingung {
            get { return this.bedingung; }
        }
        private Item belohnung;
        public Item Belohnung {
            get { return this.belohnung; }
        }
        private string teilaufgabeArt;
        public string TeilaufgabeArt {
            get { return this.teilaufgabeArt; }
        }
        private Dialog dialog;
        public Dialog Dialog {
            get { return this.dialog; }
        }
        private string institutArt;
        public string InstitutArt {
            get { return this.institutArt; }
        }

        public Teilaufgabe(int id, Item bedingung, Item belohnung, string teilaufgabeArt, Dialog dialog, string institutArt) 
            : base(id) {
            this.bedingung = bedingung;
            this.belohnung = belohnung;
            this.teilaufgabeArt = teilaufgabeArt;
            this.dialog = dialog;
            this.institutArt = institutArt;
        }

        public override TabellenName Tabelle() {
            return TabellenName.TEILAUFGABE;
        }
    }
}
