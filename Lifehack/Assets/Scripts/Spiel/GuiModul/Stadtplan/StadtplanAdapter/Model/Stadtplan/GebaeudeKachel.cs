
using UnityEngine;
using UnityEngine.EventSystems;
using Lifehack.Spiel.GuiModul.Stadtplan.StadtplanAdapter;
using Lifehack.Spiel.GuiModul.Popup;
using Lifehack.Model.Stadtplan;
using Lifehack.Spiel.GuiModul.Steuerung;
using Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter;

namespace Lifehack.Spiel.GuiModul.Stadtplan.Model.Stadtplan {

    public class GebaeudeKachel : Kachel<Gebaeude>, IPointerClickHandler {

        private void Start() {
            gameObject.AddComponent<PolygonCollider2D>();
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
        }

        public void OnPointerClick(PointerEventData eventData) {
            SteuerungModul.Instance.SchliesseModul();
            PopupModul.Instance.AddPopupEintrag(PopupModul.Instance.GetComponent<PopupEintragFabrik>().ErzeugePopupEintrag(this.Kartenelement));
            PopupModul.Instance.OeffneModul();
        }
    }
}

