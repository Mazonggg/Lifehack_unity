
using Lifehack.Model;
using Lifehack.Model.Prozess;
using System.Collections.Generic;
using Lifehack.Model.Einrichtung;
using Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter.Model.Prozess;
using Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter.Model.Einrichtung;

namespace Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter {

    public class SimplePopupEintragFabrik {

        public static IPopupEintragAdapter[] ErzeugePopupEintraege<T>(IDatenbankEintrag[] datenbankEintraege) where T : IDatenbankEintrag {
            List<IPopupEintragAdapter> eintragAdapters = new List<IPopupEintragAdapter>();
            foreach (IDatenbankEintrag datenbankEintrag in datenbankEintraege) {
                if (datenbankEintrag.GetType() == typeof(Aufgabe)) {
                    eintragAdapters.Add(new AufgabePopupEintrag((Aufgabe)datenbankEintrag));
                } else if (datenbankEintrag.GetType() == typeof(Item)) {
                    eintragAdapters.Add(new ItemPopupEintrag((Item)datenbankEintrag));
                } else if (datenbankEintrag.GetType() == typeof(Institut)) {
                    eintragAdapters.Add(new InstitutPopupEintrag((Institut)datenbankEintrag));
                }
            }
            return eintragAdapters.ToArray();
        }
    }
}

