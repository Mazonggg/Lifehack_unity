
using UnityEngine;
using UnityEngine.EventSystems;
using Lifehack.Spiel.Gui.Stadtplan.Kachel;
using Lifehack.Model.Stadtplan;
using System.Collections.Generic;
using Lifehack.Model;

namespace Lifehack.Spiel.Gui.Stadtplan.Model.Stadtplan {

    public class GebaeudeKachelAdapter : KachelAdapter<Gebaeude>, IPointerClickHandler {

        void Start() {
            gameObject.AddComponent<PolygonCollider2D>();
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
        }

        public void OnPointerClick(PointerEventData eventData) {
            StadtplanModul.Instance.GetInhalt(new List<IKartenelement>() { this.Kartenelement });
        }
    }
}

