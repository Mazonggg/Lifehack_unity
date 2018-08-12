
using System.Collections.Generic;
using Lifehack.Anwendung.Spiel.Menue;
using Lifehack.Model;
using Lifehack.Model.Fabrik.Einrichtung;
using Lifehack.Model.Fabrik.Prozess;
using Lifehack.Model.Konstanten;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.Gui {

    public class MenueButton : MonoBehaviour, IPointerClickHandler {

        public void OnPointerClick(PointerEventData eventData) {
            MenueModul.Instance.GetInhalt(
                new List<IDatenbankEintrag> {
                    ItemFabrik.Instance.ErzeugeLeeresEintragObjekt(),
                    InstitutFabrik.Instance.ErzeugeLeeresEintragObjekt(),
                    AufgabeFabrik.Instance.ErzeugeLeeresEintragObjekt()
                });
        }
    }
}

