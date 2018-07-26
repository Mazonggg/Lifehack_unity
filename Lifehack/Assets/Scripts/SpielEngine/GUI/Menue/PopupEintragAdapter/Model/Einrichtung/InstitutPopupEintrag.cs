
using Lifehack.Model.Einrichtung;

namespace Lifehack.GUI.Menue.PopupEintragAdapter.Model.Einrichtung {

    public class InstitutPopupEintrag : PopupEintrag<Institut> {

        public InstitutPopupEintrag(Institut eintrag) : base(eintrag) { }

        protected override string GetKurzInfo() {
            return this.eintrag.Name;
        }
    }
}

