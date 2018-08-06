
using Lifehack.Model.Stadtplan;


namespace Lifehack.Spiel.Gui.Stadtplan.KachelAdapter {

    public interface IKachel<T> where T : IKartenelement {

        T Kartenelement { get; }
    }
}

