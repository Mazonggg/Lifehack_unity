
using UnityEngine;
using UnityEngine.EventSystems;
using Lifehack.Spiel.GuiModul.Stadtplan.StadtplanAdapter;
using Lifehack.Spiel.GuiModul.Popup;
using Lifehack.Model.Stadtplan;
using Lifehack.Spiel.GuiModul.Steuerung;
using Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter;
using Lifehack.Model.Einrichtung;

namespace Lifehack.Spiel.GuiModul.Stadtplan.Model.Stadtplan {

    public class WohnhausKachel : GebaeudeKachel<Wohnhaus> {

        protected override string PrototypErklaerung {
            get { return "An dieser Stelle betritt der Spieler das Gebäude und kann dort mit den Bewohnern reden, Essen machen, sich in einem Bett schlafen legen, oder was noch so in Frage käme."; }
        }
    }
}

