
using Lifehack.Anwendung;
using UnityEngine;

namespace Lifehack.Anwendung {

    public class Kamera : MonoBehaviour {

        public enum Richtung {
            LINKS,
            RECHTS,
            HOCH,
            RUNTER
        };

        public GameObject spieler;

        static Kamera _instance;
        public static Kamera Instance {
            get { return Kamera._instance; }
        }

        void Start() {
            Kamera._instance = this;
        }

        const float tempo = 0.1f;

        public void Bewegen(Richtung richtung) {
            Vector3 altePosition = gameObject.transform.position;
            this.SetPosition(altePosition, richtung);
        }

        void SetPosition(Vector3 altePosition, Richtung richtung) {
            try {
                if (spieler.GetComponent<ColliderController>().IstCollidiert) {
                    gameObject.transform.position = AenderePosition(altePosition, richtung, -10f);
                } else {
                    gameObject.transform.position = AenderePosition(altePosition, richtung, 1f);
                }
            } catch {
                Debug.Log("FEHLER");
            }
        }

        Vector3 AenderePosition(Vector3 position, Richtung richtung, float amplitude) {
            switch (richtung) {
                case Richtung.LINKS:
                    position.x -= Kamera.tempo * amplitude;
                    break;
                case Richtung.RECHTS:
                    position.x += Kamera.tempo * amplitude;
                    break;
                case Richtung.HOCH:
                    position.y += Kamera.tempo * amplitude;
                    break;
                default:
                    position.y -= Kamera.tempo * amplitude;
                    break;
            }

            return position;
        }
    }
}

