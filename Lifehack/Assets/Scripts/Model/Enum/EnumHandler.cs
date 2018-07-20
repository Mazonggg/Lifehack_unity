using System;

namespace Lifehack.Model.Enum {

    public enum TabellenName {
        AUFGABE,
        AUSSEHEN_LINK,
        GEBAEUDE,
        INSTITUT,
        INSTITUT_ART,
        INTERIEUR_LINK,
        ITEM,
        ITEM_ART,
        ITEM_AUSSEHEN_LINK,
        KARTENELEMENT,
        KARTENELEMENT_ART,
        NIEDERLASSUNG,
        PERSON,
        PERSON_AUSSEHEN_LINK,
        TEILAUFGABE,
        TEILAUFGABE_ART,
        UMWELT,
        VERTRETER,
        WOHNHAUS
    };

    public enum KartenelementArt {
        UMWELT = 1,
        GEBAEUDE = 2,
        WOHNHAUS = 3,
        NIEDERLASSUNG = 4
    };

    public enum InstitutArt {
        WOHNHAUS = 1,
        BANK = 2,
        STADTTEILBUERO = 3,
        SCHULE = 4,
        VERSICHERUNG = 5,  
        EINZELHAENDLER = 6
    };

    public enum TeilaufgabeArt {
        ITEM_WIRD_ABGEGEBEN = 1,
        ITEM_WIRD_BEHALTEN = 2
    };

    public enum ItemArt {
        GEGENSTAND = 1,
        DOKUMENT = 2,
        VERTRAG = 3,
        FORMULAR = 4,
        BANKKONTO = 5,
        CHIPKARTE = 6
    };

    public class EnumHandler {
        public static string AlsString(System.Enum enumWert) {
            return System.Enum.GetName(enumWert.GetType(), enumWert).ToLower();
        }
    }
}

