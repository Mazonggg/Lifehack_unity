
using Lifehack.Model.Stadtplan;


namespace Lifehack.Spiel.GuiModul.Stadtplan.StadtplanAdapter {

    public interface IKachelAdapter<T> where T : IKartenelement {

        T Kartenelement { get; }
    }
}

