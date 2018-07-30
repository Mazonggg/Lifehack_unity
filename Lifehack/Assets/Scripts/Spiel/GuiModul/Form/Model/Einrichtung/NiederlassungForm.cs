using UnityEngine;
using Lifehack.Model.Einrichtung;
using Lifehack.Spiel.GuiModul.Form.Model.Prozess;
using Lifehack.Model;
using Lifehack.Model.Prozess;
using Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter;
using Lifehack.Spiel.GuiModul.Popup;

namespace Lifehack.Spiel.GuiModul.Form.Model.Einrichtung {

    public class NiederlassungForm : GebaeudeForm<Niederlassung> {

        public GameObject teilaufgabeAuswahlContainer;

        protected override void InitForm() {
            foreach (Teilaufgabe teilaufgabe in ModelHandler.Instance.GetInstitutNaechsteTeilaufgaben(this.Eintrag.Institut.InstitutArt)) {
                var teilaufgabeEintrag = PopupModul.Instance.GetComponent<PopupEintragFabrik>().ErzeugePopupEintrag(teilaufgabe);
                teilaufgabeEintrag.transform.SetParent(teilaufgabeAuswahlContainer.transform);
            }
        }
    }
}

