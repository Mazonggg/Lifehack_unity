
using UnityEngine;

namespace Lifehack.Spiel.GuiModul {

    abstract public class SpielModul : MonoBehaviour, ISpielModul {

        public GameObject oeffnendesModul, schliessendesModul;

        abstract public void LeereInhalt();
        abstract protected void GetInhalt();

        public void SchliesseModul() {
            this.schliessendesModul.SetActive(false);
            this.LeereInhalt();
            oeffnendesModul.SetActive(true);
        }

        public void OeffneModul() {
            gameObject.SetActive(true);
            this.GetInhalt();
        }
    }
}

