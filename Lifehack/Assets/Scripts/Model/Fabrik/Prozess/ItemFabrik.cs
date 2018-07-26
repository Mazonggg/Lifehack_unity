
using SimpleJSON;
using Lifehack.Model.Konstanten;
using Lifehack.Model.Prozess;
using System;

namespace Lifehack.Model.Fabrik.Einrichtung {

    public class ItemFabrik : DatenbankEintragFabrik<Item> {

        private static ItemFabrik _instance;

        private ItemFabrik() { }

        public static ItemFabrik Instance() {
            if (ItemFabrik._instance == null) {
                ItemFabrik._instance = new ItemFabrik();
            }
            return ItemFabrik._instance;
        }

        protected override Item ErzeugeLeeresEintragObjekt() {
            return new Item();
        }

        protected override Item SetAttribute(Item datenbankEintrag, JSONObject json) {
            int id = -1;
            Int32.TryParse(json["item_id"].Value, out id);
            datenbankEintrag.Id = id;
            datenbankEintrag.Name = json["item_name"].Value;
            int gewicht = 0;
            Int32.TryParse(json["gewicht"].Value, out gewicht);
            datenbankEintrag.Gewicht = gewicht;
            datenbankEintrag.Konfiguration = json["konfiguration"].Value;
            datenbankEintrag.ItemArt = (ItemArt)System.Enum.Parse(typeof(ItemArt), json["item_art_ref"].Value);
            return datenbankEintrag;
        }
    }
}

