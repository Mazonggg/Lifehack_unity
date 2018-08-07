
using Lifehack.Model.Stadtplan;


namespace Lifehack.Spiel.Gui.Stadtplan.Kachel {

    public interface IKachel<T> where T : IKartenelement {

        T Kartenelement { get; }
    }
}

