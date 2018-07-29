
using UnityEngine;
using Lifehack.Model.Stadtplan;
using Lifehack.Spiel.GuiModul.Stadtplan.Model.Stadtplan;
using Lifehack.Model.Einrichtung;

namespace Lifehack.Spiel.GuiModul.Stadtplan.StadtplanAdapter {

    public class KachelFabrik : MonoBehaviour {

        public GameObject kartenelementKachel;
        public Sprite[] kartenelementSprites;

        public void ErzeugeKachel(IKartenelement kartenelement) {
            int kachelId = 0;
            foreach (Rect feld in StadtplanModul.Instance.GetAbmessung(kartenelement.Identifier).Felder) {
                GameObject kachel = Instantiate(this.kartenelementKachel);
                if (typeof(Umwelt).IsAssignableFrom(kartenelement.GetType())) {
                    kachel.AddComponent<UmweltKachel>();
                    kachel.GetComponent<UmweltKachel>().Kartenelement = (Umwelt)kartenelement;
                } else if (typeof(Niederlassung).IsAssignableFrom(kartenelement.GetType())) {
                    kachel.AddComponent<NiederlassungKachel>();
                    kachel.GetComponent<NiederlassungKachel>().Kartenelement = (Niederlassung)kartenelement;
                } else if (typeof(Wohnhaus).IsAssignableFrom(kartenelement.GetType())) {
                    kachel.AddComponent<WohnhausKachel>();
                    kachel.GetComponent<WohnhausKachel>().Kartenelement = (Wohnhaus)kartenelement;
                } else {
                    kachel.AddComponent<GebaeudeKachel<Gebaeude>>();
                    kachel.GetComponent<GebaeudeKachel<Gebaeude>>().Kartenelement = (Gebaeude)kartenelement;
                }
                kachel.name = kartenelement.KartenelementArt.ToString() + "-" + kartenelement.Id + "_" + kachelId++;
                Sprite sprite = this.GetSprite(kartenelement.KartenelementAussehen);
                kachel.GetComponent<SpriteRenderer>().sprite = sprite;
                kachel.transform.position = new Vector2(feld.x + (feld.width / 2), feld.y - (feld.height / 2));
                kachel.transform.localScale = this.GetObjektScale(sprite, feld.size) * 4;
                kachel.transform.SetParent(gameObject.transform);
                kachel.SetActive(true);
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
            float breite = feld.x / (sprite.rect.width / StadtplanModul.Instance.KachelGroesse);
            float hoehe = feld.y / (sprite.rect.height / StadtplanModul.Instance.KachelGroesse);
            return new Vector2(breite, hoehe);
        }
    }
}

