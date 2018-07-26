using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lifehack.Spielengine.GUI {

    public class KameraController : MonoBehaviour {

        public enum Richtung {
            LINKS,
            RECHTS,
            HOCH,
            RUNTER
        };

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

