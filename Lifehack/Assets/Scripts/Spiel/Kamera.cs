﻿
using Lifehack.Spiel;
using UnityEngine;

namespace Lifehack.Spiel {

    public class Kamera : MonoBehaviour {

        public enum Richtung {
            LINKS,
            RECHTS,
            HOCH,
            RUNTER
        };

        public GameObject spieler;

        private static Kamera _instance;
        public static Kamera Instance {
            get { return Kamera._instance; }
        }

        private void Start() {
            Kamera._instance = this;
        }

        private readonly float tempo = 0.1f;

        public void Bewegen(Richtung richtung) {
            Vector3 altePosition = gameObject.transform.position;
            this.SetPosition(altePosition, richtung);
        }

        private void SetPosition(Vector3 altePosition, Richtung richtung) {
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

        private Vector3 AenderePosition(Vector3 position, Richtung richtung, float amplitude) {
            switch (richtung) {
                case Richtung.LINKS:
                    position.x -= this.tempo * amplitude;
                    break;
                case Richtung.RECHTS:
                    position.x += this.tempo * amplitude;
                    break;
                case Richtung.HOCH:
                    position.y += this.tempo * amplitude;
                    break;
                case Richtung.RUNTER:
                    position.y -= this.tempo * amplitude;
                    break;
            }
            return position;
        }
    }
}

