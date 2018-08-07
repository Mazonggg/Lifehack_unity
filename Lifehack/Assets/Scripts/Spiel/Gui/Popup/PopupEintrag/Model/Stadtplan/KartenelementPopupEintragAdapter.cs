
using Lifehack.Model.Konstanten;
using Lifehack.Model.Stadtplan;

namespace Lifehack.Spiel.Gui.Popup.PopupEintrag.Model.Prozess {

    public class KartenelementPopupEintragAdapter : DatenbankEintragPopupEintragAdapter<Kartenelement> {

        const string betreten = " betreten";

        public override string GetPopupTitel() {
            return EnumHandler.AlsString(this.eintrag.KartenelementArt);
        }

        protected override string GetKurzInfo() {
            return EnumHandler.AlsString(this.eintrag.Tabelle()) + KartenelementPopupEintragAdapter.betreten;
        }
    }
}

