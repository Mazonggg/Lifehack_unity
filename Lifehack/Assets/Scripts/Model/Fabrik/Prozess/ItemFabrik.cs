
using SimpleJSON;
using Lifehack.Model.Konstanten;
using Lifehack.Model.Prozess;
using System;

namespace Lifehack.Model.Fabrik.Prozess {

    public class ItemFabrik : DatenbankEintragFabrik<Item> {

        static ItemFabrik _instance;

        ItemFabrik() { }

        public static ItemFabrik Instance {
            get {
                if (ItemFabrik._instance == null) {
                    ItemFabrik._instance = new ItemFabrik();
                }
                return ItemFabrik._instance;
            }
        }

        protected override Item ErzeugeLeeresEintragObjekt() {
            return new Item();
        }

        protected override Item SetAttribute(Item datenbankEintrag, JSONObject json) {
            datenbankEintrag.Id = json["item_id"].Value;
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

