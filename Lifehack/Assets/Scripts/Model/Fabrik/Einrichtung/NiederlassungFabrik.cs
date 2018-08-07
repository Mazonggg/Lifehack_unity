
using SimpleJSON;
using Lifehack.Model.Konstanten;
using Lifehack.Model.Stadtplan;
using System;
using Lifehack.Model.Einrichtung;

namespace Lifehack.Model.Fabrik.Stadtplan {

    public class NiederlassungFabrik : GebaeudeFabrik<Niederlassung> {

        static NiederlassungFabrik _instance;

        protected NiederlassungFabrik() { }

        public new static NiederlassungFabrik Instance {
            get {
                if (NiederlassungFabrik._instance == null) {
                    NiederlassungFabrik._instance = new NiederlassungFabrik();
                }
                return NiederlassungFabrik._instance;
            }
        }

        public override KartenelementArt GetKartenelementArt {
            get { return KartenelementArt.NIEDERLASSUNG; }
        }

        public override Niederlassung ErzeugeLeeresEintragObjekt() {
            return new Niederlassung();
        }

        protected override Niederlassung SetAttribute(Niederlassung datenbankEintrag, JSONObject json) {
            datenbankEintrag.Institut = ModelHandler.Instance.GetInstitut(json["niederlassung_institut_ref"].Value);
            return base.SetAttribute(datenbankEintrag, json);
        }
    }
}

