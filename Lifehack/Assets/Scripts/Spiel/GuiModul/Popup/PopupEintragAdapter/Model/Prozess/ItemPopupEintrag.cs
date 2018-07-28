
using Lifehack.Model.Prozess;

namespace Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter.Model.Prozess {

    public class ItemPopupEintrag : PopupEintrag<Item> {

        protected override string GetKurzInfo() {
            return this.eintrag.Name;
        }
    }
}

