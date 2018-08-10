
using Lifehack.Model.Konstanten;
using Lifehack.Model.Stadtplan;
using UnityEngine;

namespace Lifehack.Anwendung.Spiel.Stadtplan.Kachel {

    public class KachelAdapter<T> : ModulEintragAdapter<T>, IKachel<T> where T : IKartenelement {

        T kartenelement;

        public T Kartenelement {
            get { return this.kartenelement; }
            set { this.kartenelement = value; }
        }

        public override string GetEintragInhalt() {
            return StringHelfer.Ucfirst(EnumHandler.AlsString(this.eintrag.Tabelle()));
        }
    }
}

