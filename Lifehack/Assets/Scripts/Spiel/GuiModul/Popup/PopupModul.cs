
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Lifehack.Spiel.GuiModul.Popup {

    public class PopupModul : SpielModul {

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

        List<GameObject> popupEintraege = new List<GameObject>();
        public void AddPopupEintrag(GameObject eintrag) {
            this.popupEintraege.Add(eintrag);
        }

        public void SetzeTitel(string titel) {
            this.popupTitel.GetComponent<Text>().text = titel;
        }

        protected override void GetInhalt() {
            this.content.transform.DetachChildren();
            for (int i = 0; i < popupEintraege.Count; i++) {
                popupEintraege[i].transform.SetParent(this.content.transform);
                this.PositioniereEintrag(popupEintraege[i], i);
            }
            this.PasseContentGroesseAn();
            return;
        }

        public override void LeereInhalt() {
            this.popupTitel.GetComponent<Text>().text = "";
            foreach (Transform child in this.content.transform) {
                Destroy(child.gameObject);
            }
            this.popupEintraege = new List<GameObject>();
        }

        void PositioniereEintrag(GameObject eintrag, int index) {
            Vector2 min = eintrag.GetComponent<RectTransform>().offsetMin;
            min = new Vector2(0, -120 - (120 * index));
            eintrag.GetComponent<RectTransform>().offsetMin = min;
            Vector2 max = eintrag.GetComponent<RectTransform>().offsetMax;
            max = new Vector2(0, -30 - (120 * index));
            eintrag.GetComponent<RectTransform>().offsetMax = max;
        }

        void PasseContentGroesseAn() {
            float offSetMinY = PopupModul.gesamtPlatz;
            foreach (GameObject popupEintrag in this.popupEintraege) {
                offSetMinY -= popupEintrag.GetComponent<RectTransform>().sizeDelta.y + PopupModul.zwischenRaum;
            }
            this.content.GetComponent<RectTransform>().offsetMin = new Vector2(0, offSetMinY);
            this.content.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        }
    }
}

