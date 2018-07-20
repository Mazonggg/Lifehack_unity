
using SimpleJSON;
using Lifehack.Model.Enum;
using Lifehack.Model.Stadtplan;
using System;

namespace Lifehack.Model.Fabrik.Stadtplan {

    public class WohnhausFabrik<T> : GebaeudeFabrik<T> where T : Wohnhaus {

        private static WohnhausFabrik<Wohnhaus> _instance;

        protected WohnhausFabrik() { }

        public new static WohnhausFabrik<Wohnhaus> Instance() {
            if (WohnhausFabrik<Wohnhaus>._instance == null) {
                WohnhausFabrik<Wohnhaus>._instance = new WohnhausFabrik<Wohnhaus>();
            }
            return WohnhausFabrik<Wohnhaus>._instance;
        }

        public override KartenelementArt GetKartenelementArt() {
            return KartenelementArt.WOHNHAUS;
        }

        protected override IDatenbankEintrag ErzeugeLeeresEintragObjekt() {
            return new Wohnhaus();
        }

        protected override IDatenbankEintrag SetAttribute(T datenbankEintrag, JSONObject json) {
            int wohneinheiten = 0;
            Int32.TryParse(json["wohneinheiten"].Value, out wohneinheiten);
            datenbankEintrag.Wohneinheiten = wohneinheiten;
            return base.SetAttribute(datenbankEintrag, json);
        }
    }
}

