using UnityEngine;
using Lifehack.Model.Einrichtung;
using Lifehack.Spiel.Gui.Form.Model.Prozess;
using Lifehack.Model;
using Lifehack.Model.Prozess;
using Lifehack.Spiel.Gui.Popup;
using Lifehack.Spiel.Gui.Form.InputAdapter;

namespace Lifehack.Spiel.Gui.Form.Model.Einrichtung {

    public class NiederlassungFormAdapter : GebaeudeFormAdapter<Niederlassung> {

        public GameObject teilaufgabeAuswahlContainer;

        protected override void InitForm() {
            foreach (Teilaufgabe teilaufgabe in ModelHandler.Instance.GetInstitutNaechsteTeilaufgaben(this.Eintrag.Institut.InstitutArt)) {
                var teilaufgabeEintrag = FormModulAdapter.Instance.GetComponent<InputFabrik>().ErzeugeFormInput(teilaufgabe);
                teilaufgabeEintrag.transform.SetParent(teilaufgabeAuswahlContainer.transform);
            }
        }

        public override string GetPopupTitel() {
            return this.Eintrag.Institut.Name;
        }
    }
}

