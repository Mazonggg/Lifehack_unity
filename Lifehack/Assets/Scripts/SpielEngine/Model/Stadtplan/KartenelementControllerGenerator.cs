
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Lifehack.Model.Stadtplan;

namespace Lifehack.SpielEngine.Model.Stadtplan {

    public class KartenelementControllerGenerator : MonoBehaviour {

        public GameObject kartenelemenPrefab;
        public Sprite[] kartenelementSprites;

        private static KartenelementControllerGenerator _instance;
        public static KartenelementControllerGenerator Instance {
            get { return KartenelementControllerGenerator._instance; }
        }

        private void Start() {
            KartenelementControllerGenerator._instance = this;
        }

        public void ErzeugeKartenelementObjekt(IKartenelement kartenelement) {
            GameObject kartenelementObjekt = Instantiate(this.kartenelemenPrefab);
            kartenelementObjekt.name = kartenelement.KartenelementArt.ToString() + "-" + kartenelement.Id;
            //kartenelementObjekt.transform.position =
            kartenelementObjekt.GetComponent<KartenelementController>().Kartenelement = kartenelement;
            kartenelementObjekt.GetComponent<SpriteRenderer>().sprite = this.GetSprite(kartenelement.KartenelementAussehen);
            ModelHandler.Log("kartenelementAussehen: " + kartenelement.KartenelementAussehen.Split('.')[0]);
        }

        private Sprite GetSprite(string kartenelementAussehen) {
            foreach (Sprite sprite in this.kartenelementSprites) {
                ModelHandler.Log("sprite.name: " + sprite.name);
                if (sprite.name.Equals(kartenelementAussehen.Split('.')[0])) {
                    return sprite;
                }
            }
            return null;
        }
    }
}

