
using SimpleJSON;
using Lifehack.Model.Konstanten;
using Lifehack.Model.Stadtplan;
using System;
using UnityEngine;

namespace Lifehack.Model.Fabrik.Stadtplan {

    public class UmweltFabrik : KartenelementFabrik<Umwelt> {

        static UmweltFabrik _instance;

        protected UmweltFabrik() { }

        public static UmweltFabrik Instance {
            get {
                if (UmweltFabrik._instance == null) {
                    UmweltFabrik._instance = new UmweltFabrik();
                }
                return UmweltFabrik._instance;
            }
        }

        public override KartenelementArt GetKartenelementArt {
            get { return KartenelementArt.UMWELT; }
        }

        public override Umwelt ErzeugeLeeresEintragObjekt() {
            return new Umwelt();
        }

        protected override Umwelt SetAttribute(Umwelt datenbankEintrag, JSONObject json) {
            bool begehbar = true;
            if (!json["begehbar"].IsNull) {
                begehbar = json["begehbar"].Value.Equals("1");
            }
            datenbankEintrag.Begehbar = begehbar;
            return base.SetAttribute(datenbankEintrag, json);
        }
    }
}

