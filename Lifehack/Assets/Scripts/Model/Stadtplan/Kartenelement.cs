
using Lifehack.Model.Enum;

namespace Lifehack.Model.Stadtplan {

    public abstract class Kartenelement : DatenbankEintrag, IKartenelement {

        protected string kartenelementAussehen;
        public string KartenelementAussehen {
            get { return this.kartenelementAussehen; }
            set { this.kartenelementAussehen = value; }
        }

        abstract public KartenelementArt KartenelementArt { get; }

        private string identifier;
        public string Identifier {
            get { return this.identifier; }
            set { this.identifier = value; }
        }

        public override TabellenName Tabelle() {
            return TabellenName.KARTENELEMENT;
        }

        public override string ToString() {
            return "KARTENELEMENT: identifier: " + this.identifier + "; kartenelementArt: " + this.KartenelementArt + "; kartenelementAussehen: " + this.kartenelementAussehen;
        }
    }
}

