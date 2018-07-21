using System;
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
            JSONNode jsonInformation = JSON.Parse(antwort)["information"];

            ModelHandler.Instance.Institute = new DatenbankEintragDirektor<Institut>().ParseJsonZuObjekten(jsonInformation["institut"], InstitutFabrik.Instance());

            ModelHandler.Instance.Items = new DatenbankEintragDirektor<Item>().ParseJsonZuObjekten(jsonInformation["item"], ItemFabrik.Instance());

            ModelHandler.Instance.Aufgaben = new DatenbankEintragDirektor<Aufgabe>().ParseJsonZuObjekten(jsonInformation["aufgabe"], AufgabeFabrik.Instance());

            List<Kartenelement> kartenelemente = new List<Kartenelement>();
            kartenelemente.AddRange(new DatenbankEintragDirektor<Umwelt>().ParseJsonZuObjekten(jsonInformation["kartenelement"], UmweltFabrik.Instance()));
            kartenelemente.AddRange(new DatenbankEintragDirektor<Gebaeude>().ParseJsonZuObjekten(jsonInformation["kartenelement"], GebaeudeFabrik<Gebaeude>.Instance()));
            kartenelemente.AddRange(new DatenbankEintragDirektor<Wohnhaus>().ParseJsonZuObjekten(jsonInformation["kartenelement"], WohnhausFabrik.Instance()));
            kartenelemente.AddRange(new DatenbankEintragDirektor<Niederlassung>().ParseJsonZuObjekten(jsonInformation["kartenelement"], NiederlassungFabrik.Instance()));
            Dictionary<string, Kartenelement> kartenelementTable = new Dictionary<string, Kartenelement>();
            foreach (Kartenelement kartenelement in kartenelemente) {
                kartenelementTable.Add(kartenelement.Identifier, kartenelement);
            }
            ModelHandler.Instance.Kartenelemente = kartenelementTable;

            Debug.Log(ModelHandler.Instance.ToString());
        }
    }
}

