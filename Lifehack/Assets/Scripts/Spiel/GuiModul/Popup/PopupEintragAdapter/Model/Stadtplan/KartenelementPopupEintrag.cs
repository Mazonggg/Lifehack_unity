
using Lifehack.Model.Konstanten;
using Lifehack.Model.Stadtplan;

namespace Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter.Model.Prozess {

    public class KartenelementPopupEintrag : DatenbankEintragPopupEintrag<Kartenelement> {

        const string betreten = " betreten";

        protected override string GetKurzInfo() {
            return EnumHandler.AlsString(this.eintrag.Tabelle()) + KartenelementPopupEintrag.betreten;
        }
    }
}

