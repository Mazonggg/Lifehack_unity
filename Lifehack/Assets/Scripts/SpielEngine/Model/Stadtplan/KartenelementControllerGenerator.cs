﻿
using UnityEngine;
using Lifehack.Model.Stadtplan;

namespace Lifehack.SpielEngine.Model.Stadtplan {

    public class KartenelementControllerGenerator : MonoBehaviour {

        public GameObject kartenelemenPrefab;
        public GameObject kachelPrefab;
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
            kartenelementObjekt.GetComponent<KartenelementController>().Kartenelement = kartenelement;
            kartenelementObjekt.transform.parent = gameObject.transform;
            int kachelId = 0;
            foreach (Rect feld in StadtplanController.Instance.GetAbmessung(kartenelement.Identifier).Felder) {
                GameObject kachel = Instantiate(this.kachelPrefab);
                kachel.name = kartenelement.KartenelementArt.ToString() + "-" + kartenelement.Id + "_" + kachelId++;
                kachel.GetComponent<SpriteRenderer>().sprite = this.GetSprite(kartenelement.KartenelementAussehen);
                kachel.transform.position = new Vector2(feld.x + (feld.width / 2), feld.y + (feld.height / 2));
                kachel.transform.localScale = feld.size;
                kachel.transform.parent = kartenelementObjekt.transform;
            }
        }

        private Sprite GetSprite(string kartenelementAussehen) {
            foreach (Sprite sprite in this.kartenelementSprites) {
                if (sprite.name.Equals(kartenelementAussehen.Split('.')[0])) {
                    return sprite;
                }
            }
            return null;
        }
    }
}

