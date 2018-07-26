
using SimpleJSON;
using System;
using Lifehack.Model.Stadtplan;
using Lifehack.Model.Konstanten;

namespace Lifehack.Model.Fabrik.Stadtplan {

    abstract public class KartenelementFabrik<T> : DatenbankEintragFabrik<T> where T : Kartenelement {

        abstract public KartenelementArt GetKartenelementArt { get; }

        protected override T SetAttribute(T datenbankEintrag, JSONObject json) {
            int id = -1;
            Int32.TryParse(json["kartenelement_id"].Value, out id);
            datenbankEintrag.Id = id;
            datenbankEintrag.KartenelementAussehen = json["kartenelement_aussehen_url"].Value;
            datenbankEintrag.Identifier = json["ascii_identifier"].Value;
            return datenbankEintrag;
        }

        public override IDatenbankEintrag ErzeugeDantebankEintrag(JSONObject jsonObjekt) {
            if (jsonObjekt["kartenelement_art_name"].IsNull || !jsonObjekt["kartenelement_art_name"].Value.Equals(EnumHandler.AlsString(this.GetKartenelementArt))) {
                return null;
            } else {
                return base.ErzeugeDantebankEintrag(jsonObjekt);
            }
        }
    }
}

