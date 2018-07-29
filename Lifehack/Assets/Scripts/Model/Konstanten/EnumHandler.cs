using System;

namespace Lifehack.Model.Konstanten {

    public enum TabellenName {
        ABMESSUNG,
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
        BANK = 1,
        STADTTEILBUERO = 2,
        SCHULE = 3,
        VERSICHERUNG = 4,
        EINZELHAENDLER = 5
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

    public enum Status {
        OFFEN,
        AKTIV,
        BEENDET,
        GESCHEITERT,
        NICHT_ERHALTEN
    };

    public static class EnumHandler {
        public static string AlsString(Enum enumWert) {
            return Enum.GetName(enumWert.GetType(), enumWert).ToLower();
        }
    }
}

