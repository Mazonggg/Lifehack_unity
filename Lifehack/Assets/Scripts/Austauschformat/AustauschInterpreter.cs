using System;
using System.Collections.Generic;
using Lifehack.Model;
using Lifehack.Model.Enum;
using SimpleJSON;
using Lifehack.Model.Fabrik.Einrichtung;
using Lifehack.Model.Fabrik;
using Lifehack.Model.Fabrik.Stadtplan;
using Lifehack.Model.Stadtplan;
using Lifehack.Model.Einrichtung;

namespace Lifehack.Austauschformat {

    public class AustauschInterpreter {

        private static AustauschInterpreter _instance;

        private AustauschInterpreter() { }

        public static AustauschInterpreter Instance() {
            if (AustauschInterpreter._instance == null) {
                AustauschInterpreter._instance = new AustauschInterpreter();
            }
            return AustauschInterpreter._instance;
        }

        public IDatenbankEintrag[] erzeugeElementArt(TabellenName tabellenName, JSONObject json) {
            var elementArtInformationen = json[Enum.GetName(typeof(TabellenName), tabellenName).ToLower()];//.Children;
            List<IDatenbankEintrag> elemente = new List<IDatenbankEintrag>();

            switch (tabellenName) {
                case TabellenName.INSTITUT:
                    elemente.AddRange(DatenbankEintragDirektor.Instance().ArrayZuObjekten(elementArtInformationen, InstitutFabrik.Instance()));
                    break;
                case TabellenName.ITEM:
                    elemente.AddRange(DatenbankEintragDirektor.Instance().ArrayZuObjekten(elementArtInformationen, ItemFabrik.Instance()));
                    break;
                case TabellenName.AUFGABE:
                    elemente.AddRange(DatenbankEintragDirektor.Instance().ArrayZuObjekten(elementArtInformationen, AufgabeFabrik.Instance()));
                    break;
                case TabellenName.KARTENELEMENT:
                    //elemente.AddRange(DatenbankEintragDirektor.Instance().ArrayZuObjekten(elementArtInformationen, UmweltFabrik<Umwelt>.Instance()));
                    elemente.AddRange(DatenbankEintragDirektor.Instance().ArrayZuObjekten(elementArtInformationen, GebaeudeFabrik<Gebaeude>.Instance()));
                    elemente.AddRange(DatenbankEintragDirektor.Instance().ArrayZuObjekten(elementArtInformationen, WohnhausFabrik<Wohnhaus>.Instance()));
                    //elemente.AddRange(DatenbankEintragDirektor.Instance().ArrayZuObjekten(elementArtInformationen, NiederlassungFabrik<Niederlassung>.Instance()));
                    break;
                default:
                    break;
            }
            return elemente.ToArray();
        }
    }
}
