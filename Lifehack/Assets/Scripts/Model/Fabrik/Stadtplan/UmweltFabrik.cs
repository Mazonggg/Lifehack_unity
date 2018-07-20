
using SimpleJSON;
using Lifehack.Model.Enum;
using Lifehack.Model.Stadtplan;
using System;

namespace Lifehack.Model.Fabrik.Stadtplan {

    public class UmweltFabrik<T> : KartenelementFabrik<T> where T : Umwelt {

        private static UmweltFabrik<Umwelt> _instance;

        protected UmweltFabrik() { }

        public new static UmweltFabrik<Umwelt> Instance() {
            if (UmweltFabrik<Umwelt>._instance == null) {
                UmweltFabrik<Umwelt>._instance = new UmweltFabrik<Umwelt>();
            }
            return UmweltFabrik<Umwelt>._instance;
        }

        public override KartenelementArt GetKartenelementArt() {
            return KartenelementArt.WOHNHAUS;
        }

        protected override IDatenbankEintrag ErzeugeLeeresEintragObjekt() {
            return new Wohnhaus();
        }

        protected override IDatenbankEintrag SetAttribute(T datenbankEintrag, JSONObject json) {
            bool begehbar = true;
            Boolean.TryParse(json["wohneinheiten"].Value, out begehbar);
            datenbankEintrag.Begehbar = begehbar;
            return base.SetAttribute(datenbankEintrag, json);
        }
    }
}

