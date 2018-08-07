
using Lifehack.Model.Prozess;
using Lifehack.Spiel.Gui.Form.FormEintrag.Model.Prozess;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.Gui.Form.FormEintrag.Input.Model.Prozess {

    public class ItemInputAdapter : ButtonInputAdapter<Item> {

        protected override string GetKurzInfo() {
            return this.eintrag.Name;
        }

        public override void OnPointerClick(PointerEventData eventData) {
            FindObjectOfType<TeilaufgabeFormAdapter>().WaehleItem(this.eintrag);
        }
    }
}

