using UnityEngine;
using Lifehack.Model.Einrichtung;
using Lifehack.Spiel.GuiModul.Form.Model.Prozess;
using Lifehack.Model;
using Lifehack.Model.Prozess;
using Lifehack.Spiel.GuiModul.Popup;
using Lifehack.Spiel.GuiModul.Form.InputAdapter;
using Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter;

namespace Lifehack.Spiel.GuiModul.Form.Model.Einrichtung {

    public class NiederlassungForm : GebaeudeForm<Niederlassung> {

        public GameObject teilaufgabeAuswahlContainer;

        protected override void InitForm() {
            foreach (Teilaufgabe teilaufgabe in ModelHandler.Instance.GetInstitutNaechsteTeilaufgaben(this.Eintrag.Institut.InstitutArt)) {
                var teilaufgabeEintrag = FormModul.Instance.GetComponent<FormInputFabrik>().ErzeugeFormInput(teilaufgabe);
                teilaufgabeEintrag.transform.SetParent(teilaufgabeAuswahlContainer.transform);
            }
        }
    }
}

