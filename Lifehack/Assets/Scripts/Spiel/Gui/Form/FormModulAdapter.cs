
using Lifehack.Model;
using Lifehack.Spiel.Gui.Form;
using UnityEngine;

namespace Lifehack.Spiel.Gui.Popup {

    public class FormModulAdapter : ModulAdapter<IDatenbankEintrag> {

        public GameObject content;

        static FormModulAdapter _instance;
        public static FormModulAdapter Instance {
            get { return FormModulAdapter._instance; }
        }

        void Start() {
            FormModulAdapter._instance = this;
            gameObject.SetActive(false);
        }

        public override void LeereInhalt() {
            PopupModulAdapter.Instance.LeereInhalt();
        }

        public override void GetInhalt(IDatenbankEintrag inhalt) {
            this.LeereInhalt();
            PopupModulAdapter.Instance.GetInhalt(new GameObject[] { GetComponent<SimpleFormFabrik>().ErzeugeForm(inhalt) }, this);
        }

        public override string GetPopupTitel() {
            return "FormModul";
        }
    }
}

