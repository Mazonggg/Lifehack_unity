
using Lifehack.Model.Konstanten;

namespace Lifehack.Model.Prozess {

    public class Item : DatenbankEintrag {

        private ItemArt itemArt;
        public ItemArt ItemArt {
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

        private string konfiguration;
        public string Konfiguration {
            get { return konfiguration; }
            set { this.konfiguration = value; }
        }

        public Item() : base() { }

        public override TabellenName Tabelle() {
            return TabellenName.ITEM;
        }

        public override string ToString() {
            return "ITEM: id:" + this.Id + "; Name: " + this.name + "; Gewicht: " + this.gewicht + "; Konfiguration: " + this.konfiguration + "; item_art: " + this.itemArt.ToString();
        }
    }
}

