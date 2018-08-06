
using UnityEngine;
using UnityEngine.EventSystems;
using Lifehack.Spiel.Gui.Stadtplan.KachelAdapter;
using Lifehack.Model.Stadtplan;

namespace Lifehack.Spiel.Gui.Stadtplan.Model.Stadtplan {

    public class GebaeudeKachelAdapter : KachelAdapter<Gebaeude>, IPointerClickHandler {

        void Start() {
            gameObject.AddComponent<PolygonCollider2D>();
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
        }

        public void OnPointerClick(PointerEventData eventData) {
            StadtplanModulAdapter.Instance.GetInhalt(this.Kartenelement);
        }
    }
}

