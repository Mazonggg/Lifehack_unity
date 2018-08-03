
using Lifehack.Model.Stadtplan;
using UnityEngine;

namespace Lifehack.Spiel.GuiModul.Stadtplan.KachelAdapter {

    public class Kachel<T> : MonoBehaviour, IKachelAdapter<T> where T : IKartenelement {

        T kartenelement;

        public T Kartenelement {
            get { return this.kartenelement; }
            set { this.kartenelement = value; }
        }
    }
}

