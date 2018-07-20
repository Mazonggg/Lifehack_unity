using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using Lifehack.Model.Enum;
using Lifehack.Model;

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

        public static AustauschAbrufer _instance;

        private void Start() {
            AustauschAbrufer._instance = this;
            Debug.Log(AustauschAbrufer._instance);
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
            JSONObject jsonInformation = (JSONObject)JSON.Parse(antwort)["information"].AsObject;

            IDatenbankEintrag[] institute = AustauschInterpreter.Instance().erzeugeElementArt(TabellenName.INSTITUT, jsonInformation);
            foreach (IDatenbankEintrag institut in institute) {
                Debug.Log(institut);
            }
            IDatenbankEintrag[] items = AustauschInterpreter.Instance().erzeugeElementArt(TabellenName.ITEM, jsonInformation);
            foreach (IDatenbankEintrag item in items) {
                Debug.Log(item);
            }
            IDatenbankEintrag[] aufgaben = AustauschInterpreter.Instance().erzeugeElementArt(TabellenName.AUFGABE, jsonInformation);
            foreach (IDatenbankEintrag aufgabe in aufgaben) {
                Debug.Log(aufgabe);
            }
            IDatenbankEintrag[] gebaeudes = AustauschInterpreter.Instance().erzeugeElementArt(TabellenName.KARTENELEMENT, jsonInformation);
            foreach (IDatenbankEintrag gebaeude in gebaeudes) {
                Debug.Log(gebaeude);
            }
        }
    }
}

