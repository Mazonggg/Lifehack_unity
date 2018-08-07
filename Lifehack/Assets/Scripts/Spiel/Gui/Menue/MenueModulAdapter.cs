
using Lifehack.Spiel.Gui.Popup;
using UnityEngine;
using System.Collections.Generic;
using Lifehack.Model;
using Lifehack.Spiel.Gui.Menue.MenueEintrag;
using UnityEngine.UI;
using Lifehack.Model.Konstanten;

namespace Lifehack.Spiel.Gui.Menue {

    public class MenueModulAdapter : ModulAdapter<IDatenbankEintrag, IDatenbankEintrag> {

        public GameObject menueEintragPrefab;

        static MenueModulAdapter _instance;
        public static MenueModulAdapter Instance {
            get { return MenueModulAdapter._instance; }
        }

        void Start() {
            MenueModulAdapter._instance = this;
        }

        public override void LeereInhalt() {
            return;
        }

        public override void GetInhalt(List<IDatenbankEintrag> eintraege) {
            PopupModulAdapter.Instance.SetInhalt(this.ErzeugeEintragAdapters(eintraege), this);
        }

        public override string GetPopupTitel() {
            return "Menü";
        }

        protected override GameObject ErzeugeEintragAdapter(IDatenbankEintrag datenbankEintrag) {
            var menueEintrag = Instantiate(this.menueEintragPrefab);
            menueEintrag.GetComponentInChildren<MenueEintragAdapter>().Tabelle = datenbankEintrag.Tabelle();
            menueEintrag.GetComponentInChildren<Text>().text = StringHelfer.Ucfirst(EnumHandler.AlsString(datenbankEintrag.Tabelle()));
            return menueEintrag;
        }
    }
}

