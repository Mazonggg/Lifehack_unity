using Lifehack.Model;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lifehack.Spiel.GuiModul.Form.InputAdapter {

    abstract public class ButtonFormInput<T> : FormInput<T>, IPointerClickHandler where T : IDatenbankEintrag {

        public abstract void OnPointerClick(PointerEventData eventData);
    }
}

