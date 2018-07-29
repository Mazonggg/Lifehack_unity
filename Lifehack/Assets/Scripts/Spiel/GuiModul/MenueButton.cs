
using Lifehack.Model.Konstanten;
using Lifehack.Spiel.GuiModul.Steuerung;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.GuiModul {

    public class MenueButton : MonoBehaviour, IPointerClickHandler {

        public void OnPointerClick(PointerEventData eventData) {
            SteuerungModul.Instance.GetInhalt(
                new TabellenName[] {
                    TabellenName.ITEM,
                    TabellenName.INSTITUT,
                    TabellenName.AUFGABE
                });
        }
    }
}

