
using SimpleJSON;
using Lifehack.Model.Konstanten;
using Lifehack.Model.Stadtplan;
using System;
using Lifehack.Model.Einrichtung;

namespace Lifehack.Model.Fabrik.Stadtplan {

    public class NiederlassungFabrik : GebaeudeFabrik<Niederlassung> {

        private static NiederlassungFabrik _instance;

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

        protected override Niederlassung ErzeugeLeeresEintragObjekt() {
            return new Niederlassung();
        }

        protected override Niederlassung SetAttribute(Niederlassung datenbankEintrag, JSONObject json) {

            int institutId = 0;
            Int32.TryParse(json["niederlassung_institut_ref"].Value, out institutId);

            datenbankEintrag.Institut = ModelHandler.Instance.GetInstitut(institutId);
            return base.SetAttribute(datenbankEintrag, json);
        }
    }
}

