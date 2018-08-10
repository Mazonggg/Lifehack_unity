
using Lifehack.Model;
using Lifehack.Model.Konstanten;
using Lifehack.Spiel.Gui.Popup;
using UnityEngine;

namespace Lifehack.Spiel.Gui.Form.FormEintrag {

    abstract public class FormAdapter<T> : MonoBehaviour, IForm<T> where T : IDatenbankEintrag {

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

        public string GetEintragInhalt() {
            return StringHelfer.Ucfirst(EnumHandler.AlsString(this.eintrag.Tabelle()));
        }
    }
}

