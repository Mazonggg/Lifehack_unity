using UnityEngine;
using System.Collections;
using Lifehack.Spielengine.GuiModul.Stadtplan;
using UnityEngine.EventSystems;
using Lifehack.SpielEngine.GuiModul.Popup;
using Lifehack.Spielengine.GuiModul.Stadtplan.Kachel;

namespace Lifehack.SpielEngine.GuiModul.Stadtplan.Model.Stadtplan {

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

