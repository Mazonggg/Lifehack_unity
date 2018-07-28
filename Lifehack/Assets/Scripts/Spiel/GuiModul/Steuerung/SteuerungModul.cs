using UnityEngine;
using System.Collections;
using Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter;
using Lifehack.Model;

namespace Lifehack.Spiel.GuiModul.Steuerung {

    public class SteuerungModul : SpielModul {

        private static SteuerungModul _instance;
        public static SteuerungModul Instance {
            get { return SteuerungModul._instance; }
        }

        private void Start() {
            SteuerungModul._instance = this;
        }

        protected override void GetInhalt() {
            return;
        }

        public override void LeereInhalt() {
            return;
        }
    }
}

