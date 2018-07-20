
using SimpleJSON;
using Lifehack.Model.Enum;
using Lifehack.Model.Prozess;
using System;

namespace Lifehack.Model.Fabrik.Einrichtung {

    public class TeilaufgabeFabrik : DatenbankEintragFabrik<Teilaufgabe> {

        private static TeilaufgabeFabrik _instance;

        private TeilaufgabeFabrik() { }

        public static TeilaufgabeFabrik Instance() {
            if (TeilaufgabeFabrik._instance == null) {
                TeilaufgabeFabrik._instance = new TeilaufgabeFabrik();
            }
            return TeilaufgabeFabrik._instance;
        }

        protected override IDatenbankEintrag ErzeugeLeeresEintragObjekt() {
            return new Teilaufgabe();
        }

        protected override IDatenbankEintrag SetAttribute(Teilaufgabe datenbankEintrag, JSONObject json) {
            int id = -1;
            Int32.TryParse(json["teilaufgabe_id"].Value, out id);
            datenbankEintrag.Id = id;
            datenbankEintrag.Dialog = new Dialog(
                json["menue_text"].Value,
                json["ansprache_text"].Value,
                json["antwort_text"].Value,
                json["erfuellungs_text"].Value,
                json["scheitern_text"].Value);
            datenbankEintrag.TeilaufgabeArt = (TeilaufgabeArt)System.Enum.Parse(typeof(TeilaufgabeArt), json["teilaufgabe_art_ref"].Value);
            datenbankEintrag.InstitutArt = (InstitutArt)System.Enum.Parse(typeof(InstitutArt), json["teilaufgabe_art_ref"].Value);
            return datenbankEintrag;
        }
    }
}

