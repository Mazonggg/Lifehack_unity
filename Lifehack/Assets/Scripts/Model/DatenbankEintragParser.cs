
using System.Collections.Generic;
using Lifehack.Model.Fabrik;
using SimpleJSON;

namespace Lifehack.Model {

    public class DatenbankEintragParser<T> where T : IDatenbankEintrag {

        public DatenbankEintragParser() { }

        public T[] ArrayZuObjekten(JSONNode elementDatens, IDatenbankEintragFabrik<IDatenbankEintrag> fabrik) {
            List<T> eintraege = new List<T>();
            //ModelHandler.Log(elementDatens.ToString());
            foreach (JSONNode elementDaten in elementDatens.Children) {
                //ModelHandler.Log(elementDaten.ToString());
                T element = (T)fabrik.ErzeugeDantebankEintrag(elementDaten.AsObject);
                if (element != null) {
                    // ModelHandler.Log(element.ToString());
                    eintraege.Add(element);
                }
            }
            return eintraege.ToArray();
        }
    }
}

