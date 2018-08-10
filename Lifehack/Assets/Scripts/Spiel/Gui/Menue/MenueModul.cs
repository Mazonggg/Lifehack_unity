
using Lifehack.Spiel.Gui.Popup;
using UnityEngine;
using System.Collections.Generic;
using Lifehack.Model;
using Lifehack.Spiel.Gui.Menue.MenueEintrag;
using UnityEngine.UI;
using Lifehack.Model.Konstanten;

namespace Lifehack.Spiel.Gui.Menue {

    public class MenueModul : Modul<IDatenbankEintrag, IDatenbankEintrag> {

        public GameObject menueEintragPrefab;

        static MenueModul _instance;
        public static MenueModul Instance {
            get { return MenueModul._instance; }
        }

        void Start() {
            MenueModul._instance = this;
        }

        public override void LeereInhalt() {
            return;
        }

        public override void GetInhalt(List<IDatenbankEintrag> eintraege) {
            PopupModul.Instance.SetInhalt(this.ErzeugeEintragAdapters(eintraege), this);
        }

        public override string GetPopupTitel() {
            return "Menü";
        }

        protected override GameObject ErzeugeEintragAdapter(IDatenbankEintrag eintrag) {
            var menueEintrag = Instantiate(this.menueEintragPrefab);
            menueEintrag.GetComponentInChildren<MenueEintragAdapter>().Eintrag = eintrag;
            menueEintrag.GetComponentInChildren<Text>().text = StringHelfer.Ucfirst(EnumHandler.AlsString(eintrag.Tabelle()));
            return menueEintrag;
        }
    }
}

