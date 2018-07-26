
using Lifehack.Model.Prozess;

namespace Lifehack.GUI.Menue.PopupEintragAdapter.Model.Prozess {

    public class ItemPopupEintrag : PopupEintrag<Item> {

        public ItemPopupEintrag(Item eintrag) : base(eintrag) { }

        protected override string GetKurzInfo() {
            return this.eintrag.Name;
        }
    }
}

