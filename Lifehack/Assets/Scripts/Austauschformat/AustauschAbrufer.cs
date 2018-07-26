using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

/*
 * Nutzt https://github.com/Bunny83/SimpleJSON unter Beruecksichtigung 
 * der MIT License, wie im Verzeichnis: 
 * Lifehack/Assets/Scripts/Austauschformat/SimpleJSON-master
 * zu finden.
 */
namespace Lifehack.Austauschformat {

    public class AustauschAbrufer {

        private static AustauschAbrufer _instance;
        public static AustauschAbrufer Instance {
            get {
                if (AustauschAbrufer._instance == null) {
                    AustauschAbrufer._instance = new AustauschAbrufer();
                }
                return AustauschAbrufer._instance;
            }
        }

        private static string jsonAnfrage = "http://zielke.projekte.onlinelabor.fh-luebeck.de/Lifehack/?modus=JSON";
        private UnityWebRequest anfrage;

        public IEnumerator FrageJsonAn(Action<string> callback) {
            using (anfrage = UnityWebRequest.Get(jsonAnfrage)) {
                yield return anfrage.SendWebRequest();
                try {
                    callback(anfrage.downloadHandler.text);
                } catch (Exception e) {
                    Debug.Log("AustauschAbrufer.FrageJSONan() -> Exception: " + e);
                }
            }
        }
    }
}

