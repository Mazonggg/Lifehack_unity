
using Lifehack.Model.Konstanten;
using Lifehack.Model.Stadtplan;

namespace Lifehack.Spiel.Gui.Popup.PopupEintragAdapter.Model.Prozess {

    public class KartenelementPopupEintragAdapter : DatenbankEintragPopupEintragAdapter<Kartenelement> {

        const string betreten = " betreten";

        public override string GetPopupTitel() {
            return "TÄST";
        }

        protected override string GetKurzInfo() {
            return EnumHandler.AlsString(this.eintrag.Tabelle()) + KartenelementPopupEintragAdapter.betreten;
        }
    }
}

