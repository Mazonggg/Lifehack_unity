
using Lifehack.Model;
using UnityEngine;

namespace Lifehack.Spiel.GuiModul.Form {

    abstract public class Form<T> : MonoBehaviour, IFormAdapter where T : IDatenbankEintrag {

        T eintrag;
        public T Eintrag {
            get { return this.eintrag; }
            set { this.eintrag = value; }
        }
    }
}

