using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using RestSharp.Contrib;

/*
 * Nutzt https://github.com/Bunny83/SimpleJSON 
 * und https://github.com/Cratesmith/RestSharp-for-unity3d
 */
namespace Lifehack.Austauschformat {

    public class AustauschAbrufer : MonoBehaviour {

        public GameObject modelHandler;

        const string jsonAnfrage = "http://zielke.projekte.onlinelabor.fh-luebeck.de/Lifehack/?modus=JSON";
        UnityWebRequest anfrage;

        static AustauschAbrufer _instance;
        public static AustauschAbrufer Instance {
            get { return AustauschAbrufer._instance; }
        }

        JSONNode json;
        public JSONNode Information {
            get { return this.json[AustauschKonstanten.INFORMATION]; }
        }
        public JSONNode Karte {
            get { return this.json[AustauschKonstanten.KARTE]; }
        }
        public JSONNode Konfiguration {
            get { return this.json[AustauschKonstanten.KONFIGURATION]; }
        }

        void Start() {
            AustauschAbrufer._instance = this;
            StartCoroutine(this.FrageJsonAn());
        }

        IEnumerator FrageJsonAn() {
            using (anfrage = UnityWebRequest.Get(AustauschAbrufer.jsonAnfrage)) {
                yield return anfrage.SendWebRequest();
                try {
                    this.json = JSON.Parse(HttpUtility.HtmlDecode(anfrage.downloadHandler.text));
                    modelHandler.SetActive(true);
                } catch (Exception e) {
                    Debug.Log("AustauschAbrufer.FrageJSONan() -> Exception: " + e);
                }
            }
        }
    }
}

