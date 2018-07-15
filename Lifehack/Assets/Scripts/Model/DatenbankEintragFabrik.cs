using System;
using SimpleJSON;

namespace Lifehack.Model {

    abstract public class DatenbankEintragFabrik<T> where T : DatenbankEintrag {

        abstract protected T ErzeugeLeersEintragObjekt();
        abstract protected T SetAttribute(T datenbankEintrag, JSONObject eintragDaten);

        public T ErzeugeEintragObjekt(JSONObject eintragDaten) {
            T eintrag = this.ErzeugeLeersEintragObjekt();
            if (eintragDaten.IsObject) {
                return this.SetAttribute(eintrag, eintragDaten);
            }
            return eintrag;
        }
    }
}

