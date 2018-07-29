using UnityEngine;
using System.Collections;
using Lifehack.Model.Prozess;
using UnityEngine.UI;
using Lifehack.Model.Konstanten;

namespace Lifehack.Spiel.GuiModul.Form.Model.Prozess {

    public class ItemForm : Form<Item> {

        public GameObject itemArtText, gewichtText, konfigurationText;

        void Start() {
            itemArtText.GetComponent<Text>().text = StringHelfer.Ucfirst(EnumHandler.AlsString(this.Eintrag.ItemArt));
            gewichtText.GetComponent<Text>().text = this.Eintrag.Gewicht.ToString();
            konfigurationText.GetComponent<Text>().text = this.Eintrag.Konfiguration;
        }
    }
}

