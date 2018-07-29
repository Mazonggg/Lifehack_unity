
using Lifehack.Model.Konstanten;

namespace Lifehack.Model.Stadtplan {

    public abstract class Kartenelement : DatenbankEintrag, IKartenelement {

        protected string kartenelementAussehen;
        public string KartenelementAussehen {
            get { return this.kartenelementAussehen; }
            set { this.kartenelementAussehen = value; }
        }

        abstract public KartenelementArt KartenelementArt { get; }

        string identifier;
        public string Identifier {
            get { return this.identifier; }
            set { this.identifier = value; }
        }

        public override TabellenName Tabelle() {
            return TabellenName.KARTENELEMENT;
        }
    }
}

