using UnityEngine;
using UnityEngine.UI;
using Lifehack.Anwendung.Spiel.Stadtplan;

namespace Lifehack.Anwendung.Spiel {

    public class WechselButton : MonoBehaviour {

        public GameObject spielModulContainer;

        void Start() {
            GetComponent<Button>().onClick.AddListener(this.spielModulContainer.GetComponent<IModul>().SchliesseModul);
        }
    }
}

