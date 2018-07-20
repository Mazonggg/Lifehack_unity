﻿
using Lifehack.Model.Einrichtung;
using SimpleJSON;
using System;
using Lifehack.Model.Prozess;
using System.Collections.Generic;

namespace Lifehack.Model.Fabrik.Einrichtung {

    public class AufgabeFabrik : DatenbankEintragFabrik<Aufgabe> {

        private static AufgabeFabrik _instance;

        private AufgabeFabrik() { }

        public static AufgabeFabrik Instance() {
            if (AufgabeFabrik._instance == null) {
                AufgabeFabrik._instance = new AufgabeFabrik();
            }
            return AufgabeFabrik._instance;
        }

        protected override IDatenbankEintrag ErzeugeLeeresEintragObjekt() {
            return new Aufgabe();
        }

        protected override IDatenbankEintrag SetAttribute(Aufgabe datenbankEintrag, JSONObject json) {
            int id = -1;
            Int32.TryParse(json["aufgabe_id"].Value, out id);
            datenbankEintrag.Id = id;
            datenbankEintrag.Bezeichnung = json["bezeichnung"].Value;
            datenbankEintrag.Gesetzesgrundlage = json["gesetzesgrundlage"].Value;
            List<Teilaufgabe> teilaufgaben = new List<Teilaufgabe>();
            foreach (JSONObject teilaufgabeDaten in json["teilaufgabe"]) {
                datenbankEintrag.Gesetzesgrundlage += " # ";
                teilaufgaben.Add((Teilaufgabe)TeilaufgabeFabrik.Instance().ErzeugeDantebankEintrag(teilaufgabeDaten.AsObject));
            }
            datenbankEintrag.Teilaufgaben = teilaufgaben;
            return datenbankEintrag;
        }
    }
}

