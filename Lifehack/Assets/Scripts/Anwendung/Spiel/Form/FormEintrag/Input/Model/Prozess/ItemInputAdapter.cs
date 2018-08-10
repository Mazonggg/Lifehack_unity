
using Lifehack.Model.Prozess;
using Lifehack.Anwendung.Spiel.Form.FormEintrag.Model.Prozess;
using UnityEngine.EventSystems;

namespace Lifehack.Anwendung.Spiel.Form.FormEintrag.Input.Model.Prozess {

    public class ItemInputAdapter : ButtonInputAdapter<Item> {

        protected override string GetKurzInfo() {
            return this.eintrag.Name;
        }

        public override void OnPointerClick(PointerEventData eventData) {
            FindObjectOfType<TeilaufgabeFormAdapter>().WaehleItem(this.eintrag);
        }
    }
}

