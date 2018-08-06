
using Lifehack.Spiel.Gui.Popup;
using UnityEngine;

namespace Lifehack.Spiel.Gui {

    abstract public class ModulAdapter<T> : MonoBehaviour, IModul, IPopupTitelgeber {

        public GameObject oeffnendesModul, schliessendesModul;

        abstract public void LeereInhalt();
        abstract public void GetInhalt(T inhalt);
        abstract public string GetPopupTitel();

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

