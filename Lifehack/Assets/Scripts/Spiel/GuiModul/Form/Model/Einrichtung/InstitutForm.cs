using UnityEngine;
using System.Collections;
using Lifehack.Model.Einrichtung;
using Lifehack.Model.Konstanten;
using UnityEngine.UI;
using Lifehack.Model.Prozess;
using Lifehack.Model;

namespace Lifehack.Spiel.GuiModul.Form.Model.Einrichtung {

    public class InstitutForm : Form<Institut> {

        public GameObject institutArtText, beschreibungText, aufgabenListe;

        void Start() {
            institutArtText.GetComponent<Text>().text = StringHelfer.Ucfirst(EnumHandler.AlsString(this.Eintrag.InstitutArt));
            beschreibungText.GetComponent<Text>().text = this.Eintrag.Beschreibung;
            foreach (Teilaufgabe teilaufgabe in ModelHandler.Instance.GetInstitutNaechsteTeilaufgaben(this.Eintrag.InstitutArt)) {
                aufgabenListe.GetComponent<Text>().text += "- " + teilaufgabe.Dialog.MenueText + "\n";
            }
        }
    }
}

