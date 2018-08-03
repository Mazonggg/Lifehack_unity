
using UnityEngine;
using UnityEngine.EventSystems;
using Lifehack.Spiel.GuiModul.Stadtplan.KachelAdapter;
using Lifehack.Model.Stadtplan;

namespace Lifehack.Spiel.GuiModul.Stadtplan.Model.Stadtplan {

    public class GebaeudeKachel : Kachel<Gebaeude>, IPointerClickHandler {

        void Start() {
            gameObject.AddComponent<PolygonCollider2D>();
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
        }

        public void OnPointerClick(PointerEventData eventData) {
            StadtplanModul.Instance.GetInhalt(this.Kartenelement);
        }
    }
}

