using UnityEngine;
using System.Collections;

namespace Lifehack.SpielEngine {

    public class ColliderController : MonoBehaviour {

        private bool istCollidiert = false;
        public bool IstCollidiert {
            get { return this.istCollidiert; }
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            this.istCollidiert = true;
        }

        private void OnTriggerExit2D(Collider2D collision) {
            this.istCollidiert = false;
        }
    }
}

