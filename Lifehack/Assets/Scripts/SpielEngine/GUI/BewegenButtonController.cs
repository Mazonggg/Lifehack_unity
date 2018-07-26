using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Lifehack.Spielengine.GUI {

    public class BewegenButtonController : MonoBehaviour {

        public KameraController hauptKamera;
        public KameraController.Richtung richtung;

        private void Start() {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(this.BewegeKamera);
        }

        private void BewegeKamera() {
            hauptKamera.Bewegen(this.richtung);
        }
    }
}

