
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Spielengine.GuiModul.Stadtplan {

    public class BewegenButtonController : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler {

        public KameraController.Richtung richtung;
        private bool innerhalb = false;

        public void OnPointerEnter(PointerEventData eventData) {
            this.innerhalb = true;
        }

        public void OnPointerExit(PointerEventData eventData) {
            this.innerhalb = false;
        }

        private void FixedUpdate() {
            if (Input.GetMouseButton(0) && this.innerhalb) {
                KameraController.Instance.Bewegen(this.richtung);
            }
        }
    }
}

