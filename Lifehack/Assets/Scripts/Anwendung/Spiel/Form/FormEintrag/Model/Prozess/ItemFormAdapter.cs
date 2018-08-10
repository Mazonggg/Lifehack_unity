using UnityEngine;
using System.Collections;
using Lifehack.Model.Prozess;
using UnityEngine.UI;
using Lifehack.Model.Konstanten;

namespace Lifehack.Anwendung.Spiel.Form.FormEintrag.Model.Prozess {

    public class ItemFormAdapter : FormAdapter<Item> {

        public GameObject itemArtText, gewichtText, konfigurationText;

        protected override void InitForm() {
            itemArtText.GetComponent<Text>().text = StringHelfer.Ucfirst(EnumHandler.AlsString(this.Eintrag.ItemArt));
            gewichtText.GetComponent<Text>().text = this.Eintrag.Gewicht.ToString();
            konfigurationText.GetComponent<Text>().text = this.Eintrag.Konfiguration;
        }

        public override string GetPopupTitel() {
            return this.Eintrag.Name;
        }
    }
}

