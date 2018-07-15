using System;
using Lifehack.Model;
using Lifehack.Model.Enum;

namespace Lifehack.Model.Aufgabe {

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
        private string teilaufgabe_art;
        public string Teilaufgabe_art {
            get { return this.teilaufgabe_art; }
            set { this.teilaufgabe_art = value; }
        }
        private Dialog dialog;
        public Dialog Dialog {
            get { return this.dialog; }
            set { this.dialog = value; }
        }
        private string institut_art;
        public string InstitutArt {
            get { return this.institut_art; }
            set { this.institut_art = value; }
        }

        public override TabellenName Tabelle<TabellenName>() {
            return TabellenName.TEILAUFGABE;
        }
    }
}
