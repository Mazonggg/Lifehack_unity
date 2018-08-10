
using Lifehack.Model.Stadtplan;
using Lifehack.Anwendung.Spiel.Stadtplan.Kachel;
using UnityEngine;

namespace Lifehack.Anwendung.Spiel.Stadtplan.Model.Stadtplan {

    public class UmweltKachelAdapter : KachelAdapter<Umwelt> {
        
        void Start() {
            if (!this.Kartenelement.Begehbar) {
                gameObject.AddComponent<PolygonCollider2D>();
                gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
            }
        }
    }
}

