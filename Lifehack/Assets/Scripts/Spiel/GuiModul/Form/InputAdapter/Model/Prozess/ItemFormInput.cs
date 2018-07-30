
using Lifehack.Model.Prozess;
using Lifehack.Spiel.GuiModul.Form.Model.Prozess;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.GuiModul.Form.InputAdapter.Model.Prozess {

    public class ItemFormInput : ButtonFormInput<Item> {

        protected override string GetKurzInfo() {
            return this.eintrag.Name;
        }

        public override void OnPointerClick(PointerEventData eventData) {
            FindObjectOfType<TeilaufgabeForm>().WaehleItem(this.eintrag);
        }
    }
}

