
using UnityEngine;
using UnityEngine.EventSystems;
using Lifehack.Spiel.GuiModul.Popup;
using Lifehack.Spiel.GuiModul.Stadtplan.StadtplanController;

namespace Lifehack.Spiel.GuiModul.Stadtplan.Model.Stadtplan {

    public class GebaeudeKachelController : KachelController, IPointerClickHandler {
        private void Start() {
            gameObject.AddComponent<PolygonCollider2D>();
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
        }

        public void OnPointerClick(PointerEventData eventData) {
            if (PopupModul.Instance == null || !PopupModul.Instance.gameObject.activeInHierarchy) {
                Debug.Log("HUHU: " + gameObject.name);
            }
        }
    }
}

