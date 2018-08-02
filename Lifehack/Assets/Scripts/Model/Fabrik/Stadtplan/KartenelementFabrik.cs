
using SimpleJSON;
using System;
using Lifehack.Model.Stadtplan;
using Lifehack.Model.Konstanten;

namespace Lifehack.Model.Fabrik.Stadtplan {

    abstract public class KartenelementFabrik<T> : DatenbankEintragFabrik<T> where T : Kartenelement {

        abstract public KartenelementArt GetKartenelementArt { get; }

        protected override T SetAttribute(T datenbankEintrag, JSONObject json) {
            datenbankEintrag.Id = json["kartenelement_id"].Value;
            datenbankEintrag.KartenelementAussehen = json["kartenelement_aussehen_url"].Value;
            return datenbankEintrag;
        }

        public override IDatenbankEintrag ErzeugeDantebankEintrag(JSONObject jsonObjekt) {
            if (!jsonObjekt["kartenelement_art_name"].IsNull && jsonObjekt["kartenelement_art_name"].Value.Equals(EnumHandler.AlsString(this.GetKartenelementArt))) {
                return base.ErzeugeDantebankEintrag(jsonObjekt);
            }
            return null;
        }
    }
}

