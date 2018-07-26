using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Lifehack.Spielengine.GuiModul.Stadtplan {

    public class BewegenButtonController : MonoBehaviour, IPointerClickHandler {

        public KameraController.Richtung richtung;

        public void OnPointerClick(PointerEventData eventData) {
            KameraController.Instance.Bewegen(this.richtung);
        }
    }
}

