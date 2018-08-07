
using Lifehack.Model.Einrichtung;
using SimpleJSON;
using Lifehack.Model.Konstanten;
using System;

namespace Lifehack.Model.Fabrik.Einrichtung {

    public class InstitutFabrik : DatenbankEintragFabrik<Institut> {

        static InstitutFabrik _instance;

        InstitutFabrik() { }

        public static InstitutFabrik Instance {
            get {
                if (InstitutFabrik._instance == null) {
                    InstitutFabrik._instance = new InstitutFabrik();
                }
                return InstitutFabrik._instance;
            }
        }

        public override Institut ErzeugeLeeresEintragObjekt() {
            return new Institut();
        }

        protected override Institut SetAttribute(Institut datenbankEintrag, JSONObject json) {
            datenbankEintrag.Id = json["institut_id"].Value;
            datenbankEintrag.Name = json["institut_name"].Value;
            datenbankEintrag.Beschreibung = json["beschreibung"].Value;
            datenbankEintrag.InstitutArt = (InstitutArt)Enum.Parse(typeof(InstitutArt), json["institut_art_ref"].Value);
            return datenbankEintrag;
        }
    }
}

