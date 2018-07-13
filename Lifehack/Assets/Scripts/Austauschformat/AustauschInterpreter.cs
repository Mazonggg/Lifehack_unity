using System;
using System.Collections.Generic;
using Lifehack.Model.Enum;
using SimpleJSON;

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

        public string[] erzeugeElementArt(TabellenName tabellenName, JSONObject json) {
            var elementArtInformation = json["information"][Enum.GetName(typeof(TabellenName), tabellenName).ToLower()].Children;
            List<string> elemente = new List<string>();
            foreach (var information in elementArtInformation) {
                elemente.Add(information.ToString());
            }
            return elemente.ToArray();
        }
    }
}
