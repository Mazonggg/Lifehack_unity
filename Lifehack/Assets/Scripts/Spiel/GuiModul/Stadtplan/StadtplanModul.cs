﻿
using System.Collections.Generic;
using Lifehack.Model.Stadtplan;
using SimpleJSON;
using System;
using Lifehack.Model;
using Lifehack.Spiel.GuiModul.Stadtplan.StadtplanAdapter;
using Lifehack.Austauschformat;
using UnityEngine;

namespace Lifehack.Spiel.GuiModul.Stadtplan {

    public class StadtplanModul : SpielModul {

        static StadtplanModul _instance;
        public static StadtplanModul Instance {
            get { return StadtplanModul._instance; }
        }

        void Start() {
            StadtplanModul._instance = this;
            this.GetInhalt();
        }

        Dictionary<string, Abmessung> abmessungen = new Dictionary<string, Abmessung>();
        int kachelGroesse;
        public int KachelGroesse {
            get { return this.kachelGroesse; }
        }

        public Abmessung GetAbmessung(string identifier) {
            return this.abmessungen[identifier];
        }

        public override void LeereInhalt() {
            return;
        }

        protected override void GetInhalt() {
            JSONNode json = AustauschAbrufer.Instance.Json;

            this.SetKonfiguration(json[AustauschKonstanten.KONFIGURATION]);
            this.SammleAbmessungen(json[AustauschKonstanten.KARTE]);
            this.PlatziereKacheln(ModelHandler.Instance.Kartenelemente);
        }

        void SetKonfiguration(JSONNode jsonKonfiguration) {
            Int32.TryParse(jsonKonfiguration[AustauschKonstanten.KACHEL_GROESSE].Value, out this.kachelGroesse);
        }

        void SammleAbmessungen(JSONNode jsonKarte) {
            foreach (string identifier in jsonKarte.Keys) {
                var abmessung = SimpleAbmessungFabrik.ErzeugeAbmessung(jsonKarte, identifier);
                this.abmessungen.Add(identifier, abmessung);
            }
        }

        void PlatziereKacheln(Dictionary<string, Kartenelement> kartenelemente) {
            foreach (string kartenelementIdentifier in kartenelemente.Keys) {
                GetComponent<KachelFabrik>().ErzeugeKachel(kartenelemente[kartenelementIdentifier]);
            }
        }
    }
}

