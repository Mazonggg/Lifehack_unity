
using Lifehack.Model.Stadtplan;
using UnityEngine;

namespace Lifehack.Spielengine.GuiModul.Stadtplan.StadtplanController{

    public class KartenelementController : MonoBehaviour {

        private IKartenelement kartenelement;
        public IKartenelement Kartenelement {
            set { this.kartenelement = value; }
        }
    }
}

