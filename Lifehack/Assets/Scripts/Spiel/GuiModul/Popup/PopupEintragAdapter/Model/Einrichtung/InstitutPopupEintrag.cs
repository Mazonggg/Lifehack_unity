
using Lifehack.Model.Einrichtung;

namespace Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter.Model.Einrichtung {

    public class InstitutPopupEintrag : PopupEintrag<Institut> {

        protected override string GetKurzInfo() {
            return this.eintrag.Name;
        }
    }
}

