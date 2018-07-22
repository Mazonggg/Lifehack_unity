﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using Lifehack.Model.Enum;
using Lifehack.Model;
using Lifehack.Model.Einrichtung;
using Lifehack.Model.Prozess;
using Lifehack.Model.Stadtplan;
using Lifehack.Model.Fabrik;
using Lifehack.Model.Fabrik.Einrichtung;
using Lifehack.Model.Fabrik.Stadtplan;
using System.Collections.Generic;

/*
 * Nutzt https://github.com/Bunny83/SimpleJSON unter Beruecksichtigung 
 * der MIT License, wie im Verzeichnis: 
 * Lifehack/Assets/Scripts/Austauschformat/SimpleJSON-master
 * zu finden.
 */
namespace Lifehack.Austauschformat {

    public class AustauschAbrufer : MonoBehaviour {
        private static string serverFehler = "Error:";
        private static string jsonAnfrage = "http://127.0.0.1/Lifehack/?modus=JSON";
        //private static string serverRequest = "http://h2678361.stratoserver.net/";
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
                    if (anfrage.isNetworkError) {
                        Debug.Log(serverFehler + anfrage.error);
                    } else {
                        string antwort = anfrage.downloadHandler.text;
                        if (antwort.StartsWith(serverFehler, StringComparison.Ordinal)) {
                            Debug.Log(serverFehler + antwort);
                        } else {
                            verarbeiteAntwort(antwort);
                        }
                    }
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

