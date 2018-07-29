
using SimpleJSON;
using Lifehack.Model.Konstanten;
using Lifehack.Model.Prozess;
using System;

namespace Lifehack.Model.Fabrik.Einrichtung {

    public class TeilaufgabeFabrik : DatenbankEintragFabrik<Teilaufgabe> {

        static TeilaufgabeFabrik _instance;

        TeilaufgabeFabrik() { }

        public static TeilaufgabeFabrik Instance {
            get {
                if (TeilaufgabeFabrik._instance == null) {
                    TeilaufgabeFabrik._instance = new TeilaufgabeFabrik();
                }
                return TeilaufgabeFabrik._instance;
            }
        }

        protected override Teilaufgabe ErzeugeLeeresEintragObjekt() {
            return new Teilaufgabe();
        }

        protected override Teilaufgabe SetAttribute(Teilaufgabe datenbankEintrag, JSONObject json) {
            int id = -1;
            Int32.TryParse(json["teilaufgabe_id"].Value, out id);
            datenbankEintrag.Id = id;
            datenbankEintrag.Dialog = new Dialog(
                json["menue_text"].Value,
                json["ansprache_text"].Value,
                json["antwort_text"].Value,
                json["erfuellungs_text"].Value,
                json["scheitern_text"].Value);
            datenbankEintrag.TeilaufgabeArt = (TeilaufgabeArt)Enum.Parse(typeof(TeilaufgabeArt), json["teilaufgabe_art_ref"].Value);
            datenbankEintrag.InstitutArt = (InstitutArt)Enum.Parse(typeof(InstitutArt), json["institut_art_ref"].Value);

            int bedingungId = 0;
            int belohnungId = 0;
            Int32.TryParse(json["bedingung_item_ref"].Value, out bedingungId);
            Int32.TryParse(json["belohnung_item_ref"].Value, out belohnungId);

            datenbankEintrag.Bedingung = ModelHandler.Instance.GetItem(bedingungId);
            datenbankEintrag.Belohnung = ModelHandler.Instance.GetItem(belohnungId);
            return datenbankEintrag;
        }
    }
}

