using UnityEngine;
using Lifehack.Model.Einrichtung;
using Lifehack.Model.Konstanten;
using UnityEngine.UI;
using Lifehack.Model.Prozess;
using Lifehack.Model;
using Lifehack.Spiel.Gui.Popup;

namespace Lifehack.Spiel.Gui.Form.FormEintrag.Model.Einrichtung {

    public class InstitutFormAdapter : FormAdapter<Institut> {

        public GameObject institutArtText, beschreibungText, aufgabenListe;

        protected override void InitForm() {
            institutArtText.GetComponent<Text>().text = StringHelfer.Ucfirst(EnumHandler.AlsString(this.Eintrag.InstitutArt));
            beschreibungText.GetComponent<Text>().text = this.Eintrag.Beschreibung;
            foreach (Teilaufgabe teilaufgabe in ModelHandler.Instance.GetInstitutNaechsteTeilaufgaben(this.Eintrag.InstitutArt)) {
                GameObject teilaufgabeInfo = FormModul.Instance.ErzeugeInfoEintrag(teilaufgabe.Dialog.MenueText);
                teilaufgabeInfo.transform.SetParent(aufgabenListe.transform);
            }
        }
    }
}

