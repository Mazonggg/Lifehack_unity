
using Lifehack.Model.Einrichtung;
using SimpleJSON;
using Lifehack.Model.Enum;
using System;

namespace Lifehack.Model.Fabrik.Einrichtung {

    public class InstitutFabrik : DatenbankEintragFabrik<Institut> {

        private static InstitutFabrik _instance;

        private InstitutFabrik() { }

        public static InstitutFabrik Instance() {
            if (InstitutFabrik._instance == null) {
                InstitutFabrik._instance = new InstitutFabrik();
            }
            return InstitutFabrik._instance;
        }

        protected override Institut ErzeugeLeeresEintragObjekt() {
            return new Institut();
        }

        protected override Institut SetAttribute(Institut datenbankEintrag, JSONObject json) {
            int id = -1;
            Int32.TryParse(json["institut_id"].Value, out id);
            datenbankEintrag.Id = id;
            datenbankEintrag.Name = json["institut_name"].Value;
            datenbankEintrag.Beschreibung = json["beschreibung"].Value;
            datenbankEintrag.InstitutArt = (InstitutArt)System.Enum.Parse(typeof(InstitutArt), json["institut_art_ref"].Value);
            return datenbankEintrag;
        }
    }
}

