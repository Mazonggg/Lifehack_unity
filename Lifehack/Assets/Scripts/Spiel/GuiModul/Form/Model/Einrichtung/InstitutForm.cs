using UnityEngine;
using System.Collections;
using Lifehack.Model.Einrichtung;
using Lifehack.Model.Konstanten;
using UnityEngine.UI;
using Lifehack.Model.Prozess;
using Lifehack.Model;
using Lifehack.Spiel.GuiModul.Popup;
using Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter;

namespace Lifehack.Spiel.GuiModul.Form.Model.Einrichtung {

    public class InstitutForm : Form<Institut> {

        public GameObject institutArtText, beschreibungText, aufgabenListe;

        protected override void InitForm() {
            institutArtText.GetComponent<Text>().text = StringHelfer.Ucfirst(EnumHandler.AlsString(this.Eintrag.InstitutArt));
            beschreibungText.GetComponent<Text>().text = this.Eintrag.Beschreibung;
            foreach (Teilaufgabe teilaufgabe in ModelHandler.Instance.GetInstitutNaechsteTeilaufgaben(this.Eintrag.InstitutArt)) {
                GameObject teilaufgabeInfo = PopupModul.Instance.GetComponent<SimplePopupEintragFabrik>().ErzeugeInfoEintrag(teilaufgabe.Dialog.MenueText);
                teilaufgabeInfo.transform.SetParent(aufgabenListe.transform);
            }
        }
    }
}

