
using Lifehack.Model;
using Lifehack.Model.Konstanten;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter.Model.Einrichtung {

    public class AuswahlPopupEintrag : PopupEintrag<TabellenName>, IPointerClickHandler {

        protected override string GetKurzInfo() {
            return EnumHandler.AlsString(this.eintrag);
        }

        public override void OnPointerClick(PointerEventData eventData) {
            PopupModul.Instance.LeereInhalt();
            var datenbankEintraege = new IDatenbankEintrag[] { };
            switch (this.eintrag) {
                case TabellenName.ITEM:
                    datenbankEintraege = ModelHandler.Instance.Items;
                    break;
                case TabellenName.INSTITUT:
                    datenbankEintraege = ModelHandler.Instance.Institute;
                    break;
                case TabellenName.AUFGABE:
                    datenbankEintraege = ModelHandler.Instance.Aufgaben;
                    break;
            }
            foreach (var datenbankEintrag in datenbankEintraege) {
                PopupModul.Instance.AddPopupEintrag(PopupModul.Instance.GetComponent<PopupEintragFabrik>().ErzeugePopupEintrag(datenbankEintrag));
            }
            PopupModul.Instance.SetzeTitel(StringHelfer.Ucfirst(EnumHandler.AlsString(this.eintrag)));
            PopupModul.Instance.OeffneModul();
        }
    }
}

