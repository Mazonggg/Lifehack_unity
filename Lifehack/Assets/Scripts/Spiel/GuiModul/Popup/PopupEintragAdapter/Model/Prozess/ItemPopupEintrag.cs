
using Lifehack.Model.Prozess;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter.Model.Prozess {

    public class ItemPopupEintrag : PopupEintrag<Item> {

        protected override string GetKurzInfo() {
            return this.eintrag.Name;
        }

        public override void OnPointerClick(PointerEventData eventData) {
            Debug.Log("ItemPopupEintrag.OnPointerClick: " + this.eintrag);
        }
    }
}

