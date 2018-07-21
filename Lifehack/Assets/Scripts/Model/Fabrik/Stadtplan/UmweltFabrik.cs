
using SimpleJSON;
using Lifehack.Model.Enum;
using Lifehack.Model.Stadtplan;
using System;

namespace Lifehack.Model.Fabrik.Stadtplan {

    public class UmweltFabrik : KartenelementFabrik<Umwelt> {

        private static UmweltFabrik _instance;

        protected UmweltFabrik() { }

        public new static UmweltFabrik Instance() {
            if (UmweltFabrik._instance == null) {
                UmweltFabrik._instance = new UmweltFabrik();
            }
            return UmweltFabrik._instance;
        }

        public override KartenelementArt GetKartenelementArt {
            get { return KartenelementArt.UMWELT; }
        }

        protected override Umwelt ErzeugeLeeresEintragObjekt() {
            return new Umwelt();
        }

        protected override Umwelt SetAttribute(Umwelt datenbankEintrag, JSONObject json) {
            bool begehbar = true;
            Boolean.TryParse(json["wohneinheiten"].Value, out begehbar);
            datenbankEintrag.Begehbar = begehbar;
            return base.SetAttribute(datenbankEintrag, json);
        }
    }
}

