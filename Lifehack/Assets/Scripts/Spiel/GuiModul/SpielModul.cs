
using UnityEngine;

namespace Lifehack.Spiel.GuiModul {

    abstract public class SpielModul<T> : MonoBehaviour, ISpielModul {

        public GameObject oeffnendesModul, schliessendesModul;

        abstract public void LeereInhalt();
        abstract public void GetInhalt(T inhalt);

        public void SchliesseModul() {
            this.schliessendesModul.SetActive(false);
            this.LeereInhalt();
            oeffnendesModul.SetActive(true);
        }

        public void OeffneModul() {
            gameObject.SetActive(true);
        }
    }
}

