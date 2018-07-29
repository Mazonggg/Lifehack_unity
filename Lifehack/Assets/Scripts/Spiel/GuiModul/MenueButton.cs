
using Lifehack.Model.Konstanten;
using Lifehack.Spiel.GuiModul.Popup;
using Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.GuiModul {

    public class MenueButton : MonoBehaviour, IPointerClickHandler {

        public void OnPointerClick(PointerEventData eventData) {

            PopupModul.Instance.AddPopupEintrag(PopupModul.Instance.GetComponent<PopupEintragFabrik>().ErzeugeAuswahlEintrag(TabellenName.ITEM));
            PopupModul.Instance.AddPopupEintrag(PopupModul.Instance.GetComponent<PopupEintragFabrik>().ErzeugeAuswahlEintrag(TabellenName.INSTITUT));
            PopupModul.Instance.AddPopupEintrag(PopupModul.Instance.GetComponent<PopupEintragFabrik>().ErzeugeAuswahlEintrag(TabellenName.AUFGABE));
            PopupModul.Instance.SetzeTitel("Menü");
            PopupModul.Instance.OeffneModul();
        }
    }
}

