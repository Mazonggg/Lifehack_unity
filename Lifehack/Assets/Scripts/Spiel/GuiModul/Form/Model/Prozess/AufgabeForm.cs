
using UnityEngine;
using Lifehack.Model.Prozess;
using Lifehack.Model;
using UnityEngine.UI;
using Lifehack.Model.Konstanten;

namespace Lifehack.Spiel.GuiModul.Form.Model.Prozess {

    public class AufgabeForm : Form<Aufgabe> {

        public GameObject statusText, gesetzesgrundlageText, teilaufgabe_info;

        protected override void InitForm() {
            statusText.GetComponent<Text>().text = StringHelfer.Ucfirst(EnumHandler.AlsString(this.Eintrag.Status));
            gesetzesgrundlageText.GetComponent<Text>().text = this.Eintrag.Gesetzesgrundlage;
            teilaufgabe_info.GetComponent<Text>().text = ModelHandler.Instance.NaechsteTeilaugabeInAufgabe(this.Eintrag).Dialog.MenueText;
        }
    }
}

