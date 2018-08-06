using Lifehack.Model;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.Gui.Form.InputAdapter {

    abstract public class ButtonInputAdapter<T> : InputAdapter<T>, IPointerClickHandler where T : IDatenbankEintrag {

        public abstract void OnPointerClick(PointerEventData eventData);
    }
}

