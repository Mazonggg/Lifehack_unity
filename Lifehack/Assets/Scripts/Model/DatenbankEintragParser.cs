
using System.Collections.Generic;
using Lifehack.Model.Fabrik;
using SimpleJSON;

namespace Lifehack.Model {

    public class DatenbankEintragParser<T> where T : IDatenbankEintrag {

        public T[] ArrayZuObjekten(JSONNode elementDatens, IDatenbankEintragFabrik<IDatenbankEintrag> fabrik) {
            var eintraege = new List<T>();
            foreach (JSONNode elementDaten in elementDatens.Children) {
                var element = (T)fabrik.ErzeugeDantebankEintrag(elementDaten.AsObject);
                if (element != null) {
                    eintraege.Add(element);
                }
            }
            return eintraege.ToArray();
        }
    }
}

