using UnityEngine;
using UnityEngine.UI;

namespace Lifehack.Spiel.GuiModul {

    abstract public class SpielModul : MonoBehaviour, ISpielModul {

        public GameObject wechselButton, oeffnendesModul, popupTitel;

        protected void Start() {
            wechselButton.GetComponent<Button>().onClick.AddListener(this.SchliesseModul);
        }

        abstract protected void LeereModul();
        abstract protected void BefuelleModul();

        public void SchliesseModul() {
            gameObject.SetActive(false);
            this.LeereModul();
            this.oeffnendesModul.GetComponent<SpielModul>().OeffneModul();
        }

        public void OeffneModul() {
            gameObject.SetActive(true);
            this.BefuelleModul();
        }
    }
}

