
using Lifehack.Model.Stadtplan;


namespace Lifehack.Spiel.GuiModul.Stadtplan.KachelAdapter {

    public interface IKachelAdapter<T> where T : IKartenelement {

        T Kartenelement { get; }
    }
}

