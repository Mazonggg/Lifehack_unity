
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.Gui.Steuerung {

    public class BewegenButton : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler {

        public Kamera.Richtung richtung;
        bool innerhalb;

        public void OnPointerEnter(PointerEventData eventData) {
            this.innerhalb = true;
        }

        public void OnPointerExit(PointerEventData eventData) {
            this.innerhalb = false;
        }

        void FixedUpdate() {
            if (Input.GetMouseButton(0) && this.innerhalb) {
                Kamera.Instance.Bewegen(this.richtung);
            }
        }
    }
}

