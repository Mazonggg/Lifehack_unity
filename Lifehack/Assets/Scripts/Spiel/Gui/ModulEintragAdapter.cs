using UnityEngine;
using System.Collections;
using Lifehack.Model;

namespace Lifehack.Spiel.Gui {

    abstract public class ModulEintragAdapter<T> : MonoBehaviour, IModulEintrag where T : IDatenbankEintrag {

        protected T eintrag;
        public T Eintrag {
            set { this.eintrag = value; }
        }

        abstract public string GetEintragInhalt();
    }
}

