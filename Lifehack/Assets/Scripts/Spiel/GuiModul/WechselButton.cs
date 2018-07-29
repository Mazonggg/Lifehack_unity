using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Lifehack.Spiel.GuiModul;

namespace Lifehack.Spiel.GuiModul {

    public class WechselButton : MonoBehaviour {

        public GameObject spielModulContainer;

        void Start() {
            GetComponent<Button>().onClick.AddListener(this.spielModulContainer.GetComponent<ISpielModul>().SchliesseModul);
        }
    }
}

