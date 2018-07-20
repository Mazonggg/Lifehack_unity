
using Lifehack.Model.Enum;

namespace Lifehack.Model.Stadtplan {

    public abstract class Kartenelement : DatenbankEintrag, IKartenelement {

        protected Abmessung[] abmessungen;
        public Abmessung[] Abmessungen {
            get { return this.abmessungen; }
            set { this.abmessungen = value; }
        }

        protected string kartenelementAussehen;
        public string KartenelementAussehen {
            get { return this.kartenelementAussehen; }
            set { this.kartenelementAussehen = value; }
        }

        protected KartenelementArt kartenelementArt;
        abstract public KartenelementArt KartenelementArt { get; }

        public override TabellenName Tabelle() {
            return TabellenName.KARTENELEMENT;
        }

        public override string ToString() {
            return "KARTENELEMENT: kartenelementArt: " + this.KartenelementArt + "; kartenelementAussehen: " + this.kartenelementAussehen;
        }
    }
}

