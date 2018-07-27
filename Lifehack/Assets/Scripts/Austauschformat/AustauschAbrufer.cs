﻿using System;
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

        public GameObject modelHandler;

        private static string jsonAnfrage = "http://zielke.projekte.onlinelabor.fh-luebeck.de/Lifehack/?modus=JSON";
        private UnityWebRequest anfrage;

        private static AustauschAbrufer _instance;
        public static AustauschAbrufer Instance {
            get { return AustauschAbrufer._instance; }
        }

        private JSONNode json;
        public JSONNode Json {
            get { return this.json; }
        }

        private void Start() {
            AustauschAbrufer._instance = this;
            StartCoroutine(this.FrageJsonAn());
        }

        private IEnumerator FrageJsonAn() {
            using (anfrage = UnityWebRequest.Get(jsonAnfrage)) {
                yield return anfrage.SendWebRequest();
                try {
                    this.json = JSON.Parse(anfrage.downloadHandler.text);
                    modelHandler.SetActive(true);
                } catch (Exception e) {
                    Debug.Log("AustauschAbrufer.FrageJSONan() -> Exception: " + e);
                }
            }
        }
    }
}

