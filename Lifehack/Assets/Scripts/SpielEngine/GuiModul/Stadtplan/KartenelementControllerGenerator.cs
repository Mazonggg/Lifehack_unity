
using UnityEngine;
using Lifehack.Model.Stadtplan;

namespace Lifehack.Spielengine.GuiModul.Stadtplan {

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
            kartenelementObjekt.transform.SetParent(gameObject.transform);
            int kachelId = 0;
            foreach (Rect feld in StadtplanController.Instance.GetAbmessung(kartenelement.Identifier).Felder) {
                GameObject kachel = Instantiate(this.kachelPrefab);
                kachel.name = kartenelement.KartenelementArt.ToString() + "-" + kartenelement.Id + "_" + kachelId++;
                Sprite sprite = this.GetSprite(kartenelement.KartenelementAussehen);
                kachel.GetComponent<SpriteRenderer>().sprite = sprite;
                kachel.transform.position = new Vector2(feld.x + (feld.width /2), feld.y - (feld.height / 2));
                kachel.transform.localScale = this.GetObjektScale(sprite, feld.size) * 4;
                kachel.transform.SetParent(kartenelementObjekt.transform);
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

        private Vector2 GetObjektScale(Sprite sprite, Vector2 feld) {
            float breite = feld.x / (sprite.rect.width / StadtplanController.Instance.KachelGroesse);
            float hoehe = feld.y / (sprite.rect.height / StadtplanController.Instance.KachelGroesse);
            return new Vector2(breite, hoehe);
        }
    }
}

