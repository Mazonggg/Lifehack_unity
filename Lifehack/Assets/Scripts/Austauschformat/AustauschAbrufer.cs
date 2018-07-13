using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using Lifehack.Model.Enum;

/*
 * Nutzt https://github.com/Bunny83/SimpleJSON unter Beruecksichtigung 
 * der MIT License, wie im Verzeichnis: 
 * Lifehack/Assets/Scripts/Austauschformat/SimpleJSON-master
 * zu finden.
 */
namespace Lifehack.Austauschformat {

    public class AustauschAbrufer : MonoBehaviour {
        // Flags for Server communication:
        private static string serverFehler = "Error:";
        private static string jsonAnfrage = "http://127.0.0.1/Lifehack/?modus=JSON";
        //private static string serverRequest = "http://h2678361.stratoserver.net/";
        private UnityWebRequest anfrage;

        private void Start() {
            macheJSONanfrage();
        }

        private void macheJSONanfrage() {
            StartCoroutine(frageJSONan());
        }

        private IEnumerator frageJSONan() {
            using (anfrage = UnityWebRequest.Get(jsonAnfrage)) {
                yield return anfrage.SendWebRequest();
                try {
                    if (anfrage.isNetworkError) {
                        Debug.Log(serverFehler + anfrage.error);
                    } else {
                        string antwort = anfrage.downloadHandler.text;
                        // Checks if the request responses with an error
                        if (antwort.StartsWith(serverFehler, StringComparison.Ordinal)) {
                            Debug.Log(serverFehler + antwort);
                        } else {
                            // Callback function:
                            verarbeiteAntwort(antwort);
                        }
                    }
                } catch (Exception e) {
                    Debug.Log("AustauschAbrufer.frageJSONan -> Exception: " + e);
                }
            }
        }

        private void verarbeiteAntwort(string antwort) {
            Debug.Log(antwort);

            Debug.Log(Enum.GetName(typeof(TabellenName), TabellenName.INSTITUT).ToLower());

            JSONObject json = (JSONObject)JSON.Parse(antwort);
            string[] institute = AustauschInterpreter.Instance().erzeugeElementArt(TabellenName.INSTITUT, json);
            foreach(string institut in institute) {
                Debug.Log(institut);
            }
        }
    }
}

