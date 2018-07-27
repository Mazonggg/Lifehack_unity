using UnityEngine;
using System.Collections;
using Lifehack.GUI.Popup.PopupEintragAdapter;

namespace Lifehack.SpielEngine.GuiModul.Popup {

    public class PopupModul : SpielModul {

        public GameObject popupEintragPrefab;
        public GameObject content;

        private static PopupModul _instance;
        public static PopupModul Instance {
            get { return PopupModul._instance; }
        }

        protected new void Start() {
            Debug.Log("HUHUUUUUUUUU");
            PopupModul._instance = this;
            base.Start();
        }

        protected override void BefuelleModul() {
            //GameObject eintrag = Instantiate(popupEintragPrefab);
            //eintrag.GetComponent<PopupEintragController>().InitPopupEintragController();
            //content
        }

        protected override void LeereModul() {
            this.content.transform.DetachChildren();
        }
    }
}

