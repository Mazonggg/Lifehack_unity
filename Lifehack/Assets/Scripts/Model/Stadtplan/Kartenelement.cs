
using Lifehack.Model.Enum;

namespace Lifehack.Model.Stadtplan {

    public abstract class Kartenelement : DatenbankEintrag {

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

        protected Kartenelement (int id, string kartenelementAussehen) : base(id) {
            this.kartenelementAussehen = kartenelementAussehen;
        }

        public override TabellenName Tabelle(){
            return TabellenName.KARTENELEMENT;
        }
    }
}

