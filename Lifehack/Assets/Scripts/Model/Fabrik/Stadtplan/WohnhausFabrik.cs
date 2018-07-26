
using SimpleJSON;
using Lifehack.Model.Konstanten;
using Lifehack.Model.Stadtplan;
using System;

namespace Lifehack.Model.Fabrik.Stadtplan {

    public class WohnhausFabrik : GebaeudeFabrik<Wohnhaus> {

        private static WohnhausFabrik _instance;

        protected WohnhausFabrik() { }

        public new static WohnhausFabrik Instance() {
            if (WohnhausFabrik._instance == null) {
                WohnhausFabrik._instance = new WohnhausFabrik();
            }
            return WohnhausFabrik._instance;
        }

        public override KartenelementArt GetKartenelementArt {
            get { return KartenelementArt.WOHNHAUS; }
        }

        protected override Wohnhaus ErzeugeLeeresEintragObjekt() {
            return new Wohnhaus();
        }

        protected override Wohnhaus SetAttribute(Wohnhaus datenbankEintrag, JSONObject json) {
            int wohneinheiten = 0;
            Int32.TryParse(json["wohneinheiten"].Value, out wohneinheiten);
            datenbankEintrag.Wohneinheiten = wohneinheiten;
            return base.SetAttribute(datenbankEintrag, json);
        }
    }
}

