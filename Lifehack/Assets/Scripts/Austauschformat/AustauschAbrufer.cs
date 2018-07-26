using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

/*
 * Nutzt https://github.com/Bunny83/SimpleJSON unter Beruecksichtigung 
 * der MIT License, wie im Verzeichnis: 
 * Lifehack/Assets/Scripts/Austauschformat/SimpleJSON-master
 * zu finden.
 */
namespace Lifehack.Austauschformat {

    public class AustauschAbrufer : MonoBehaviour {
        private static string jsonAnfrage = "http://zielke.projekte.onlinelabor.fh-luebeck.de/Lifehack/?modus=JSON";
        private UnityWebRequest anfrage;

        private void Start() {
            macheJsonAnfrage();
        }

        public void Log(string log) {
            Debug.Log(log);
        }

        private void macheJsonAnfrage() {
            StartCoroutine(frageJsonAn());
        }

        private IEnumerator frageJsonAn() {
            using (anfrage = UnityWebRequest.Get(jsonAnfrage)) {
                yield return anfrage.SendWebRequest();
                try {
                    verarbeiteAntwort(anfrage.downloadHandler.text);
                } catch (Exception e) {
                    Debug.Log("AustauschAbrufer.frageJSONan -> Exception: " + e);
                }
            }
        }

        private void verarbeiteAntwort(string antwort) {
            ModelHandler.Instance.InitModel(JSON.Parse(antwort));
        }
    }
}

