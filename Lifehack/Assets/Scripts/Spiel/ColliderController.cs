using UnityEngine;

namespace Lifehack.Spiel {

    public class ColliderController : MonoBehaviour {

        bool istCollidiert;
        public bool IstCollidiert {
            get { return this.istCollidiert; }
        }

        void OnTriggerEnter2D(Collider2D collision) {
            this.istCollidiert = true;
        }

        void OnTriggerExit2D(Collider2D collision) {
            this.istCollidiert = false;
        }
    }
}

