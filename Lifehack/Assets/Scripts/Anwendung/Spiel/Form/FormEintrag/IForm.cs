
using Lifehack.Anwendung.Spiel.Popup;

namespace Lifehack.Anwendung.Spiel.Form.FormEintrag {

    public interface IForm : IModulEintrag {}

    public interface IForm<T> : IForm, IPopupTitelgeber {
        T Eintrag { get; set; }
    }
}

