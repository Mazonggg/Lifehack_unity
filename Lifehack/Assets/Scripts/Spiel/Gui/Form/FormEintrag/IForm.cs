
using Lifehack.Spiel.Gui.Popup;

namespace Lifehack.Spiel.Gui.Form.FormEintrag {

    public interface IForm<T> : IPopupTitelgeber {
        T Eintrag { get; set; }
    }
}

