using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Lifehack.SpielEngine.GuiModul.Popup;

namespace Lifehack.Spielengine.GuiModul.Stadtplan {

    public class KachelController : MonoBehaviour, IPointerClickHandler {

        private void Start() {
            gameObject.AddComponent<PolygonCollider2D>();
        }

        public void OnPointerClick(PointerEventData eventData) {
            if (PopupModul.Instance == null || !PopupModul.Instance.gameObject.activeInHierarchy) {
                Debug.Log("HUHU: " + gameObject.name);
            }
        }
    }
}

