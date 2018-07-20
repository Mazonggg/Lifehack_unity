
using SimpleJSON;
using Lifehack.Model.Enum;
using Lifehack.Model.Stadtplan;

namespace Lifehack.Model.Fabrik.Stadtplan {

    public class GebaeudeFabrik<T> : KartenelementFabrik<T> where T : Gebaeude {

        private static GebaeudeFabrik<Gebaeude> _instance;

        protected GebaeudeFabrik() { }

        public static GebaeudeFabrik<Gebaeude> Instance() {
            if (GebaeudeFabrik<Gebaeude>._instance == null) {
                GebaeudeFabrik<Gebaeude>._instance = new GebaeudeFabrik<Gebaeude>();
            }
            return GebaeudeFabrik<Gebaeude>._instance;
        }

        public override KartenelementArt GetKartenelementArt() {
            return KartenelementArt.GEBAEUDE;
        }

        protected override IDatenbankEintrag ErzeugeLeeresEintragObjekt() {
            return new Gebaeude();
        }

        protected override IDatenbankEintrag SetAttribute(T datenbankEintrag, JSONObject json) {
            datenbankEintrag.InterieurAussehen = json["interieur_aussehen_url"].Value;
            return base.SetAttribute(datenbankEintrag, json);
        }
    }
}

