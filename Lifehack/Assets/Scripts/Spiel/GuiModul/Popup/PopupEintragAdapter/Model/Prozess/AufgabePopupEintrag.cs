
using Lifehack.Model.Prozess;

namespace Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter.Model.Prozess {

    public class AufgabePopupEintrag : PopupEintrag<Aufgabe> {

        public AufgabePopupEintrag(Aufgabe eintrag) : base(eintrag) { }

        protected override string GetKurzInfo() {
            return this.eintrag.Bezeichnung;
        }
    }
}

