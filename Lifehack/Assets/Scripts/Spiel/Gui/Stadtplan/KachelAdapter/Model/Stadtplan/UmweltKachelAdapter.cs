
using Lifehack.Model.Stadtplan;
using Lifehack.Spiel.Gui.Stadtplan.KachelAdapter;
using UnityEngine;

namespace Lifehack.Spiel.Gui.Stadtplan.Model.Stadtplan {

    public class UmweltKachelAdapter : KachelAdapter<Umwelt> {
        
        void Start() {
            if (!this.Kartenelement.Begehbar) {
                gameObject.AddComponent<PolygonCollider2D>();
                gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
            }
        }
    }
}

