
using Lifehack.Spiel.Gui.Popup.PopupEintragAdapter;
using Lifehack.Spiel.Gui.Popup;
using Lifehack.Model.Konstanten;
using UnityEngine;

namespace Lifehack.Spiel.Gui.Steuerung {

    public class SteuerungModulAdapter : ModulAdapter<TabellenName[]> {

        static SteuerungModulAdapter _instance;
        public static SteuerungModulAdapter Instance {
            get { return SteuerungModulAdapter._instance; }
        }

        void Start() {
            SteuerungModulAdapter._instance = this;
        }

        public override void LeereInhalt() {
            return;
        }

        public override void GetInhalt(TabellenName[] inhalt) {
            var auswahlEintraege = new GameObject[inhalt.Length];
            for (int i = 0; i < inhalt.Length; i++) {
                auswahlEintraege[i] = PopupModulAdapter.Instance.GetComponent<SimplePopupEintragFabrik>().ErzeugeAuswahlEintrag(inhalt[i]);
            }
            PopupModulAdapter.Instance.GetInhalt(auswahlEintraege, this);
        }

        public override string GetPopupTitel() {
            return "Menü";
        }
    }
}

