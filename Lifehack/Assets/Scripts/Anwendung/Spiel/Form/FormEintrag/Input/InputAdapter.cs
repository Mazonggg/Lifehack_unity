using Lifehack.Model;
using Lifehack.Model.Konstanten;
using UnityEngine;

namespace Lifehack.Anwendung.Spiel.Form.FormEintrag.Input {

    abstract public class InputAdapter<T> : MonoBehaviour, IInput where T : IDatenbankEintrag {

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

