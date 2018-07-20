
using SimpleJSON;
using Lifehack.Model.Enum;
using Lifehack.Model.Stadtplan;
using System;
using Lifehack.Model.Einrichtung;

namespace Lifehack.Model.Fabrik.Stadtplan {

    public class NiederlassungFabrik<T> : GebaeudeFabrik<T> where T : Niederlassung {

        private static NiederlassungFabrik<Niederlassung> _instance;

        protected NiederlassungFabrik() { }

        public new static NiederlassungFabrik<Niederlassung> Instance() {
            if (NiederlassungFabrik<Niederlassung>._instance == null) {
                NiederlassungFabrik<Niederlassung>._instance = new NiederlassungFabrik<Niederlassung>();
            }
            return NiederlassungFabrik<Niederlassung>._instance;
        }

        public override KartenelementArt GetKartenelementArt() {
            return KartenelementArt.WOHNHAUS;
        }

        protected override IDatenbankEintrag ErzeugeLeeresEintragObjekt() {
            return new Wohnhaus();
        }

        protected override IDatenbankEintrag SetAttribute(T datenbankEintrag, JSONObject json) {
            return base.SetAttribute(datenbankEintrag, json);
        }
    }
}

