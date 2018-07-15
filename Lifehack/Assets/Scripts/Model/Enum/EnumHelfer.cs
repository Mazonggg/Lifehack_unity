namespace Lifehack.Model.Enum {

    public class EnumHelfer {

        public static string TabellenNameToString(TabellenName enumName) {
            return System.Enum.GetName(typeof(TabellenName), enumName).ToLower();
        }
        public static string Kartenelement_artToString(Kartenelement_art enumName) {
            return System.Enum.GetName(typeof(Kartenelement_art), enumName).ToLower();
        }
        public static string Institut_artToString(Institut_art enumName) {
            return System.Enum.GetName(typeof(Institut_art), enumName).ToLower();
        }
        public static string Item_artToString(Item_art enumName) {
            return System.Enum.GetName(typeof(Item_art), enumName).ToLower();
        }
        public static string Teilaufgabe_artToString(Teilaufgabe_art enumName) {
            return System.Enum.GetName(typeof(Teilaufgabe_art), enumName).ToLower();
        }
    }
}

