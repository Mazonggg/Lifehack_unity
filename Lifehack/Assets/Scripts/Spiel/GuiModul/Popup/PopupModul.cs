
using UnityEngine;
using UnityEngine.UI;

namespace Lifehack.Spiel.GuiModul.Popup {

    public class PopupModul : SpielModul<GameObject[]> {

        public GameObject content, popupTitel;

        static PopupModul _instance;
        public static PopupModul Instance {
            get { return PopupModul._instance; }
        }

        const int gesamtPlatz = 440;
        const int zwischenRaum = 30;

        void Start() {
            PopupModul._instance = this;
            gameObject.SetActive(false);
        }

        public void SetzeTitel(string titel) {
            this.popupTitel.GetComponent<Text>().text = titel;
        }

        public override void LeereInhalt() {
            this.popupTitel.GetComponent<Text>().text = "";
            foreach (Transform child in this.content.transform) {
                Destroy(child.gameObject);
            }
        }

        public override void GetInhalt(GameObject[] inhalt) {
            this.content.transform.DetachChildren();
            for (int i = 0; i < inhalt.Length; i++) {
                inhalt[i].transform.SetParent(this.content.transform);
            }
            this.OeffneModul();
        }
    }
}

