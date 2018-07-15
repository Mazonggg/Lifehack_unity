using System;
using SimpleJSON;

namespace Lifehack.Model.Aufgabe {
    
    public class ItemFabrik: DatenbankEintragFabrik<Item> {

        private static ItemFabrik _instance;
        private ItemFabrik() {}

        public static ItemFabrik Instance() {
            if(ItemFabrik._instance == null) {
                ItemFabrik._instance = new ItemFabrik();
            }
            return ItemFabrik._instance;
        }

        protected override Item ErzeugeLeersEintragObjekt() {
            return new Item();
        }

        protected override Item SetAttribute(Item datenbankEintrag, JSONObject eintragDaten) {
            Item item = (Item)datenbankEintrag;
            /*item.Id = eintragDaten[];
            item.ItemArt = eintragDaten[];
            item.Name = eintragDaten[];
            item.Gewicht = eintragDaten[];
            item.Config = eintragDaten[];*/
            return item;
        }
    }
}

