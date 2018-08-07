using Lifehack.Model;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.Gui.Form.FormEintrag.Input {

    abstract public class ButtonInputAdapter<T> : InputAdapter<T>, IPointerClickHandler where T : IDatenbankEintrag {

        public abstract void OnPointerClick(PointerEventData eventData);
    }
}

