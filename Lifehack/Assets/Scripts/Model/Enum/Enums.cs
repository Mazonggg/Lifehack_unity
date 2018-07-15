using System;

namespace Lifehack.Model.Enum {

    public enum TabellenName {
        AUFGABE,
        AUSSEHEN_LINK,
        INSTITUT,
        INSTITUT_ART,
        INTERIEUR_LINK,
        ITEM,
        ITEM_ART,
        ITEM_AUSSEHEN_LINK,
        KARTENELEMENT,
        KARTENELEMENT_ART,
        PERSON,
        PERSON_AUSSEHEN_LINK,
        TEILAUFGABE,
        TEILAUFGABE_ART,
        VERTRETER
    };

    public enum Kartenelement_art {
        UMWELT,
        GEBAEUDE,
        WOHNHAUS,
        NIEDERLASSUNG
    }

    public enum Institut_art {
        WOHNHAUS,
        BANK,
        STADTTEILBUERO,
        SCHULE,
        VERSICHERUNG,
        EINZELHAENDLER
    }

    public enum Item_art {
        ITEM,
        DOKUMENT,
        VERTRAG,
        FORMULAR,
        BANKKONTO,
        CHIPKARTE
    }

    public enum Teilaufgabe_art {
        ITEM_WIRD_ABGEGEBEN,
        ITEM_WIRD_BEHALTEN
    }
}

