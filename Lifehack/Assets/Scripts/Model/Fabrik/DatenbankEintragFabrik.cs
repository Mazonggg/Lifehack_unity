
using System;
using SimpleJSON;
using UnityEngine;

namespace Lifehack.Model.Fabrik {

    abstract public class DatenbankEintragFabrik<T> : IDatenbankEintragFabrik<IDatenbankEintrag> where T : IDatenbankEintrag {

        abstract protected T ErzeugeLeeresEintragObjekt();
        abstract protected T SetAttribute(T datenbankEintrag, JSONObject json);

        public virtual IDatenbankEintrag ErzeugeDantebankEintrag(JSONObject jsonObjekt) {
            try {
                T datenbankEintrag = this.ErzeugeLeeresEintragObjekt();
                if (jsonObjekt.Count > 0) {
                    datenbankEintrag = this.SetAttribute(datenbankEintrag, jsonObjekt);
                }
                return datenbankEintrag;
            } catch (Exception e) {
                Debug.Log("DatenbankEintragFabrik.ErzeugeDantebankEintrag: EXCEPTION: " + e.Message);
                return null;
            }
        }
    }
}

