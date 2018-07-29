using System;
using System.Collections.Generic;
using Lifehack.Model.Konstanten;

namespace Lifehack.Model.Einrichtung {

    public class Institut : DatenbankEintrag {

        List<Niederlassung> niederlassungen;
        public List<Niederlassung> Niederlassungen {
            get { return this.niederlassungen; }
            set { this.niederlassungen = value; }
        }

        string name;
        public string Name {
            get { return this.name; }
            set { this.name = value; }
        }

        string beschreibung;
        public string Beschreibung {
            get { return this.beschreibung; }
            set { this.beschreibung = value; }
        }

        InstitutArt institutArt;
        public InstitutArt InstitutArt {
            get { return this.institutArt; }
            set { this.institutArt = value; }
        }

        public override TabellenName Tabelle() {
            return TabellenName.INSTITUT;
        }

        public override string ToString() {
            return "INSTITUT: id:" + this.Id + "; Name: " + this.name + "; Beschreibung: " + this.beschreibung + "; institut_art: " + this.institutArt.ToString();
        }
    }
}
