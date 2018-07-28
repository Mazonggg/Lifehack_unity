
using Lifehack.Model.Stadtplan;
using UnityEngine;

namespace Lifehack.Spiel.GuiModul.Stadtplan.StadtplanAdapter {

    public class Kachel<T> : MonoBehaviour, IKachelAdapter<T> where T : IKartenelement {

        private T kartenelement;

        public T Kartenelement {
            get { return this.kartenelement; }
            set { this.kartenelement = value; }
        }

        public Kachel() { }
    }
}

