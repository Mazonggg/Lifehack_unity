using System;

using Lifehack.Model.Enum;

namespace Lifehack.Model.Aufgabe {
    
    public class Item : DatenbankEintrag {

        private readonly string itemArt;
        public string ItemArt {
            get { return itemArt; }
        }
        private readonly string name;
        public string Name {
            get { return name; }
        }
        private readonly int gewicht;
        public int Gewicht {
            get { return gewicht; }
        }
        private readonly string config;
        public string Config {
            get { return config; }
        }

        public Item(int id, string itemArt, string name, int gewicht, string config) : base(id) {
            this.itemArt = itemArt;
            this.name = name;
            this.gewicht = gewicht;
            this.config = config;
        }

        public override TabellenName Tabelle() {
            return TabellenName.ITEM;
        }
    }
}

