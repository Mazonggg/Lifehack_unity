
using System.Collections.Generic;
using Lifehack.Model;
using Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter;
using UnityEngine;

namespace Lifehack.Spiel.GuiModul.Popup {

    public class FormModul : SpielModul<IDatenbankEintrag> {

        public GameObject content;

        static FormModul _instance;
        public static FormModul Instance {
            get { return FormModul._instance; }
        }

        void Start() {
            FormModul._instance = this;
            gameObject.SetActive(false);
        }

        List<GameObject> teilForms = new List<GameObject>();
        public void AddTeilForm(GameObject eintrag) {
            this.teilForms.Add(eintrag);
        }

        public override void LeereInhalt() {
            foreach (Transform child in this.content.transform) {
                Destroy(child.gameObject);
            }
            this.teilForms = new List<GameObject>();
        }

        public override void GetInhalt(IDatenbankEintrag inhalt) {
            PopupModul.Instance.LeereInhalt();
            // TODO hier die Logik zum Befuellen des "Formulars".
            Debug.Log("FormModul -> Eintrag:\n" + inhalt);
            PopupModul.Instance.GetInhalt(new GameObject[] { GetComponent<FormFabrik>().ErzeugeForm(inhalt) });
            PopupModul.Instance.SetzeTitel(inhalt.ToString());
        }
    }
}

