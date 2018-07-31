
using Lifehack.Model;
using Lifehack.Model.Konstanten;
using Lifehack.Spiel.GuiModul.Popup;
using UnityEngine;

namespace Lifehack.Spiel.GuiModul.Form {

    abstract public class Form<T> : MonoBehaviour, IFormAdapter, IPopupTitelgeber where T : IDatenbankEintrag {

        T eintrag;
        public T Eintrag {
            get { return this.eintrag; }
            set { this.eintrag = value; }
        }

        void Start() {
            this.InitForm();
            PopupModul.Instance.SetzeTitel(this.GetPopupTitel());
        }

        abstract protected void InitForm();

        public virtual string GetPopupTitel() {
            return StringHelfer.Ucfirst(EnumHandler.AlsString(this.eintrag.Tabelle()));
        }
    }
}

