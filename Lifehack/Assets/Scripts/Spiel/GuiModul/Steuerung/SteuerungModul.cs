
using Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter;
using Lifehack.Spiel.GuiModul.Popup;
using Lifehack.Model.Konstanten;
using UnityEngine;

namespace Lifehack.Spiel.GuiModul.Steuerung {

    public class SteuerungModul : SpielModul<TabellenName[]> {

        static SteuerungModul _instance;
        public static SteuerungModul Instance {
            get { return SteuerungModul._instance; }
        }

        void Start() {
            SteuerungModul._instance = this;
        }

        public override void LeereInhalt() {
            return;
        }

        public override void GetInhalt(TabellenName[] inhalt) {
            var auswahlEintraege = new GameObject[inhalt.Length];
            for (int i = 0; i < inhalt.Length; i++) {
                auswahlEintraege[i] = PopupModul.Instance.GetComponent<SimplePopupEintragFabrik>().ErzeugeAuswahlEintrag(inhalt[i]);
            }
            PopupModul.Instance.GetInhalt(auswahlEintraege, this);
        }

        public override string GetPopupTitel() {
            return "Menü";
        }
    }
}

