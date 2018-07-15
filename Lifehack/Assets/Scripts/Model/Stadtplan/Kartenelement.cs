
using Lifehack.Model.Enum;

namespace Lifehack.Model.Stadtplan {

    public abstract class Kartenelement : DatenbankEintrag, IKartenElement {

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

        public override Kartenelement_art Tabelle<Kartenelement_art>() {
            return Kartenelement_art.KARTENELEMENT;
        }
    }
}

