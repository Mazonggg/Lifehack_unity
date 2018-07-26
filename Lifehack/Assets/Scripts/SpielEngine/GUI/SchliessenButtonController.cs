
using UnityEngine;
using UnityEngine.UI;

namespace Lifehack.GUI.Menue {

    public class SchliessenButtonController : MonoBehaviour {

        public GameObject geschlossenerContainer, geoeffneterContainer;

        private void Start() {
            GetComponent<Button>().onClick.AddListener(this.SchliesseContainer);
        }

        private void SchliesseContainer() {
            this.geschlossenerContainer.SetActive(false);
            if (this.geoeffneterContainer != null) {
                this.geoeffneterContainer.SetActive(true);
            }
        }
    }
}

