
using UnityEngine;
using Lifehack.Model.Stadtplan;
using Lifehack.Spiel.GuiModul.Stadtplan.Model.Stadtplan;

namespace Lifehack.Spiel.GuiModul.Stadtplan.KachelAdapter {

    public class SimpleKachelFabrik : MonoBehaviour {

        public GameObject kartenelementKachelPrefab;
        public Sprite[] kartenelementSprites;

        public void ErzeugeKachel(IKartenelement kartenelement) {
            int kachelId = 0;
            foreach (Rect feld in StadtplanModul.Instance.GetAbmessung(kartenelement.Id).Felder) {
                var kachel = Instantiate(this.kartenelementKachelPrefab);
                if (typeof(Umwelt).IsAssignableFrom(kartenelement.GetType())) {
                    kachel.AddComponent<UmweltKachel>();
                    kachel.GetComponent<UmweltKachel>().Kartenelement = (Umwelt)kartenelement;
                } else {
                    kachel.AddComponent<GebaeudeKachel>();
                    kachel.GetComponent<GebaeudeKachel>().Kartenelement = (Gebaeude)kartenelement;
                }
                kachel.name = kartenelement.KartenelementArt.ToString() + "-" + kartenelement.Id + "_" + kachelId++;
                var sprite = this.GetSprite(kartenelement.KartenelementAussehen);
                kachel.GetComponent<SpriteRenderer>().sprite = sprite;
                kachel.transform.position = new Vector3(feld.x + (feld.width / 2), feld.y - (feld.height / 2), -1);
                kachel.transform.localScale = this.GetObjektScale(sprite, feld.size) * 4;
                kachel.transform.SetParent(gameObject.transform);
                kachel.SetActive(true);
            }
        }

        Sprite GetSprite(string kartenelementAussehen) {
            foreach (Sprite sprite in this.kartenelementSprites) {
                if (sprite.name.Equals(kartenelementAussehen.Split('.')[0])) {
                    return sprite;
                }
            }
            return null;
        }

        Vector2 GetObjektScale(Sprite sprite, Vector2 feld) {
            float breite = feld.x / (sprite.rect.width / StadtplanModul.Instance.KachelGroesse);
            float hoehe = feld.y / (sprite.rect.height / StadtplanModul.Instance.KachelGroesse);
            return new Vector2(breite, hoehe);
        }
    }
}

