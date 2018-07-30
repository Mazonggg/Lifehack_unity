using Lifehack.Model;
using Lifehack.Model.Konstanten;
using UnityEngine;

namespace Lifehack.Spiel.GuiModul.Form.InputAdapter {

    abstract public class FormInput<T> : MonoBehaviour, IFormInputAdapter where T : IDatenbankEintrag {

        protected T eintrag;
        public T Eintrag {
            set { this.eintrag = value; }
        }

        public string GetInputText() {
            return StringHelfer.Ucfirst(this.GetKurzInfo());
        }

        protected abstract string GetKurzInfo();
    }
}

