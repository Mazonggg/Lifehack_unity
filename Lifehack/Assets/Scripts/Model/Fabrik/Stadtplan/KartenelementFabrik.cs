
using SimpleJSON;
using System;
using Lifehack.Model.Stadtplan;
using Lifehack.Model.Enum;

namespace Lifehack.Model.Fabrik.Stadtplan {

    abstract public class KartenelementFabrik<T> : DatenbankEintragFabrik<T> where T : Kartenelement {

        abstract public KartenelementArt GetKartenelementArt();

        protected override IDatenbankEintrag SetAttribute(T datenbankEintrag, JSONObject json) {
            int id = -1;
            Int32.TryParse(json["kartenelement_id"].Value, out id);
            datenbankEintrag.Id = id;
            datenbankEintrag.KartenelementAussehen = json["kartenelement_aussehen_url"].Value;
            return datenbankEintrag;
        }
    }
}

