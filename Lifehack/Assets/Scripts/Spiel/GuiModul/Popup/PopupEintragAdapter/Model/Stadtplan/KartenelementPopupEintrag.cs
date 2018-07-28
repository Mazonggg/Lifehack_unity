
using Lifehack.Model.Konstanten;
using Lifehack.Model.Prozess;
using Lifehack.Model.Stadtplan;

namespace Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter.Model.Prozess {

    public class KartenelementPopupEintrag : PopupEintrag<Kartenelement> {

        protected override string GetKurzInfo() {
            return EnumHandler.AlsString(this.eintrag.Tabelle());
        }
    }
}

