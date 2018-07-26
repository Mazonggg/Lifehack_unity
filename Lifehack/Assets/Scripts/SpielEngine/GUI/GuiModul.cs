using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lifehack.GUI {

    public class GuiModul : MonoBehaviour {

        private static GuiModul _instance;
        public static GuiModul Instance {
            get { return GuiModul._instance; }
        }

        public GameObject steuerung_container, popup_container, overlay_container;

        // Use this for initialization
        void Start() {
            if (GuiModul._instance == null) {
                GuiModul._instance = this;
            }
        }
    }
}

