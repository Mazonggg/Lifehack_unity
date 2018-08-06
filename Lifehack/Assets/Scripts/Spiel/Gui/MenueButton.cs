
using Lifehack.Model.Konstanten;
using Lifehack.Spiel.Gui.Steuerung;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.Gui {

    public class MenueButton : MonoBehaviour, IPointerClickHandler {

        public void OnPointerClick(PointerEventData eventData) {
            SteuerungModulAdapter.Instance.GetInhalt(
                new TabellenName[] {
                    TabellenName.ITEM,
                    TabellenName.INSTITUT,
                    TabellenName.AUFGABE
                });
        }
    }
}

