using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lifehack.Spielengine.GuiModul.Stadtplan {

    public class KameraController : MonoBehaviour {

        public enum Richtung {
            LINKS,
            RECHTS,
            HOCH,
            RUNTER
        };

        private static KameraController _instance;
        public static KameraController Instance {
            get { return KameraController._instance; }
        }

        private void Start() {
            KameraController._instance = this;
        }

        private readonly float tempo = 1f;

        public void Bewegen(Richtung richtung) {
            Vector3 position = gameObject.transform.position;
            switch (richtung) {
                case Richtung.LINKS:
                    gameObject.transform.position = new Vector3(position.x - this.tempo, position.y, position.z);
                    break;
                case Richtung.RECHTS:
                    gameObject.transform.position = new Vector3(position.x + this.tempo, position.y, position.z);
                    break;
                case Richtung.HOCH:
                    gameObject.transform.position = new Vector3(position.x, position.y + this.tempo, position.z);
                    break;
                case Richtung.RUNTER:
                    gameObject.transform.position = new Vector3(position.x, position.y - this.tempo, position.z);
                    break;
            }
        }
    }
}

