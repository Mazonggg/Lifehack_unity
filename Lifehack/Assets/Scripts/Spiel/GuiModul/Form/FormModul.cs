
using Lifehack.Model;
using Lifehack.Spiel.GuiModul.Form;
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

        public override void LeereInhalt() {
            PopupModul.Instance.LeereInhalt();
        }

        public override void GetInhalt(IDatenbankEintrag inhalt) {
            this.LeereInhalt();
            PopupModul.Instance.GetInhalt(new GameObject[] { GetComponent<SimpleFormFabrik>().ErzeugeForm(inhalt) }, this);
        }

        public override string GetPopupTitel() {
            return "FormModul";
        }
    }
}

