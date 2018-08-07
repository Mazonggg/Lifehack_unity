
using SimpleJSON;
using Lifehack.Model.Konstanten;
using Lifehack.Model.Prozess;
using System;

namespace Lifehack.Model.Fabrik.Prozess {

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

        public override Teilaufgabe ErzeugeLeeresEintragObjekt() {
            return new Teilaufgabe();
        }

        protected override Teilaufgabe SetAttribute(Teilaufgabe datenbankEintrag, JSONObject json) {
            datenbankEintrag.Id = json["teilaufgabe_id"].Value;
            datenbankEintrag.Dialog = new Dialog(
                json["menue_text"].Value,
                json["ansprache_text"].Value,
                json["antwort_text"].Value,
                json["erfuellungs_text"].Value,
                json["scheitern_text"].Value);
            datenbankEintrag.TeilaufgabeArt = (TeilaufgabeArt)Enum.Parse(typeof(TeilaufgabeArt), json["teilaufgabe_art_ref"].Value);
            datenbankEintrag.InstitutArt = (InstitutArt)Enum.Parse(typeof(InstitutArt), json["institut_art_ref"].Value);
            datenbankEintrag.Bedingung = ModelHandler.Instance.GetItem(json["bedingung_item_ref"].Value);
            datenbankEintrag.Belohnung = ModelHandler.Instance.GetItem(json["belohnung_item_ref"].Value);
            return datenbankEintrag;
        }
    }
}

