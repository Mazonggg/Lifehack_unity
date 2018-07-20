
using System.Collections.Generic;
using SimpleJSON;
using Lifehack.Model.Enum;
using Lifehack.Model.Fabrik.Stadtplan;
using Lifehack.Model.Stadtplan;
using Lifehack.Austauschformat;

namespace Lifehack.Model.Fabrik {
    public class DatenbankEintragDirektor {

        private static DatenbankEintragDirektor _instance;
        private DatenbankEintragDirektor() { }

        public static DatenbankEintragDirektor Instance() {
            if (DatenbankEintragDirektor._instance == null) {
                DatenbankEintragDirektor._instance = new DatenbankEintragDirektor();
            }
            return DatenbankEintragDirektor._instance;
        }

        public IDatenbankEintrag[] ArrayZuObjekten(JSONNode elementDatens, IDatenbankEintragFabrik<IDatenbankEintrag> fabrik) {
            List<IDatenbankEintrag> eintraege = new List<IDatenbankEintrag>();
            foreach (JSONNode elementDaten in elementDatens.Children) {

                AustauschAbrufer._instance.Log(fabrik.GetType().ToString());
                AustauschAbrufer._instance.Log(typeof(KartenelementFabrik<Kartenelement>).ToString());

                AustauschAbrufer._instance.Log(fabrik.GetType().IsAssignableFrom(typeof(KartenelementFabrik<>)).ToString());


                if (!(fabrik.GetType().IsSubclassOf(typeof(KartenelementFabrik<Kartenelement>))) || this.IstRichtigeElementArt(elementDaten.AsObject, fabrik)) {
                    eintraege.Add(fabrik.ErzeugeDantebankEintrag(elementDaten.AsObject));
                }
            }
            return eintraege.ToArray();
        }

        private bool IstRichtigeElementArt(JSONObject elementDaten, IDatenbankEintragFabrik<IDatenbankEintrag> fabrik) {
            AustauschAbrufer._instance.Log("HUHU");
            return elementDaten["kartenelement_art_name"].Equals(EnumHandler.AlsString(((KartenelementFabrik<Kartenelement>)fabrik).GetKartenelementArt()));
        }
    }
}
