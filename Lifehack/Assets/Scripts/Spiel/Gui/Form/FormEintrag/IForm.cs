
using Lifehack.Spiel.Gui.Popup;

namespace Lifehack.Spiel.Gui.Form.FormEintrag {

    public interface IForm : IModulEintrag {}

    public interface IForm<T> : IForm, IPopupTitelgeber {
        T Eintrag { get; set; }
    }
}

