
using Lifehack.Model.Stadtplan;
using Lifehack.Spiel.GuiModul.Stadtplan.KachelAdapter;
using UnityEngine;

namespace Lifehack.Spiel.GuiModul.Stadtplan.Model.Stadtplan {

    public class UmweltKachel : Kachel<Umwelt> {
        
        void Start() {
            if (!this.Kartenelement.Begehbar) {
                gameObject.AddComponent<PolygonCollider2D>();
                gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
            }
        }
    }
}

