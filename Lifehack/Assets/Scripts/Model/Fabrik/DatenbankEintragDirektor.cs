
using System.Collections.Generic;
using SimpleJSON;
using Lifehack.Model.Enum;
using Lifehack.Model.Fabrik.Stadtplan;
using Lifehack.Model.Stadtplan;
using Lifehack.Austauschformat;

namespace Lifehack.Model.Fabrik {

    public class DatenbankEintragDirektor<T> where T : IDatenbankEintrag {

        public DatenbankEintragDirektor() { }

        public T[] ParseJsonZuObjekten(JSONNode elementDatens, IDatenbankEintragFabrik<IDatenbankEintrag> fabrik) {
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

