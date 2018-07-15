using System;

using Lifehack.Model.Enum;

namespace Lifehack.Model.Aufgabe {

    public class Item : DatenbankEintrag {

        private string itemArt;
        public string ItemArt {
            get { return itemArt; }
            set { this.itemArt = value; }
        }
        private string name;
        public string Name {
            get { return name; }
            set { this.name = value; }
        }
        private int gewicht;
        public int Gewicht {
            get { return gewicht; }
            set { this.gewicht = value; }
        }
        private string config;
        public string Config {
            get { return config; }
            set { this.config = value; }
        }

        public override TabellenName Tabelle<TabellenName>() {
            return TabellenName.ITEM;
        }
    }
}

