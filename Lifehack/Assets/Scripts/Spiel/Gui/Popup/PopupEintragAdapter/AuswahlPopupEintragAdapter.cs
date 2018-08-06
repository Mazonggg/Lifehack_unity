
using Lifehack.Model;
using Lifehack.Model.Konstanten;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.Gui.Popup.PopupEintragAdapter.Model.Einrichtung {

    public class AuswahlPopupEintragAdapter : PopupEintragAdapter<TabellenName>, IPointerClickHandler {

        protected override string GetKurzInfo() {
            return EnumHandler.AlsString(this.eintrag);
        }

        public override void OnPointerClick(PointerEventData eventData) {
            PopupModulAdapter.Instance.LeereInhalt();
            var datenbankEintraege = new IDatenbankEintrag[] { };
            switch (this.eintrag) {
                case TabellenName.ITEM:
                    datenbankEintraege = ModelHandler.Instance.ItemsInBesitz;
                    break;
                case TabellenName.INSTITUT:
                    datenbankEintraege = ModelHandler.Instance.Institute;
                    break;
                default:
                    datenbankEintraege = ModelHandler.Instance.Aufgaben;
                    break;
            }
            var popupEintraege = new GameObject[datenbankEintraege.Length];
            for (int i = 0; i < datenbankEintraege.Length; i++) {
                popupEintraege[i] = PopupModulAdapter.Instance.GetComponent<SimplePopupEintragFabrik>().ErzeugePopupEintrag(datenbankEintraege[i]);
            }
            PopupModulAdapter.Instance.GetInhalt(popupEintraege, this);
        }

        public override string GetPopupTitel() {
            return StringHelfer.Ucfirst(EnumHandler.AlsString(this.eintrag));
        }
    }
}

