using UnityEngine;
using Lifehack.Model.Einrichtung;
using Lifehack.Anwendung.Spiel.Form.FormEintrag.Model.Prozess;
using Lifehack.Model;
using Lifehack.Model.Prozess;
using Lifehack.Anwendung.Spiel.Form.FormEintrag.Input;

namespace Lifehack.Anwendung.Spiel.Form.FormEintrag.Model.Einrichtung {

    public class NiederlassungFormAdapter : GebaeudeFormAdapter<Niederlassung> {

        public GameObject teilaufgabeAuswahlContainer;

        protected override void InitForm() {
            foreach (Teilaufgabe teilaufgabe in ModelHandler.Instance.GetInstitutNaechsteTeilaufgaben(this.Eintrag.Institut.InstitutArt)) {
                var teilaufgabeEintrag = FormModul.Instance.GetComponent<InputFabrik>().ErzeugeFormInput(teilaufgabe);
                teilaufgabeEintrag.transform.SetParent(teilaufgabeAuswahlContainer.transform);
            }
        }

        public override string GetPopupTitel() {
            return this.Eintrag.Institut.Name;
        }
    }
}

