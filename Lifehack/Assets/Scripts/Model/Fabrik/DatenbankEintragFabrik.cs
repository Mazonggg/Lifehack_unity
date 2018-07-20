
using SimpleJSON;

namespace Lifehack.Model.Fabrik {

    abstract public class DatenbankEintragFabrik<T> : IDatenbankEintragFabrik<IDatenbankEintrag> where T : IDatenbankEintrag {

        abstract protected IDatenbankEintrag ErzeugeLeeresEintragObjekt();
        abstract protected IDatenbankEintrag SetAttribute(T datenbankEintrag, JSONObject json);

        public IDatenbankEintrag ErzeugeDantebankEintrag(JSONObject json) {
            IDatenbankEintrag datenbankEintrag = this.ErzeugeLeeresEintragObjekt();
            if (json.Count > 0) {
                datenbankEintrag = this.SetAttribute((T)datenbankEintrag, json);
            }
            return datenbankEintrag;
        }
    }
}

