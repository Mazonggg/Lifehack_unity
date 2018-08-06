
using Lifehack.Model.Stadtplan;
using UnityEngine;

namespace Lifehack.Spiel.Gui.Stadtplan.KachelAdapter {

    public class KachelAdapter<T> : MonoBehaviour, IKachel<T> where T : IKartenelement {

        T kartenelement;

        public T Kartenelement {
            get { return this.kartenelement; }
            set { this.kartenelement = value; }
        }
    }
}

