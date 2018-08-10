
using Lifehack.Model.Stadtplan;

namespace Lifehack.Anwendung.Spiel.Stadtplan.Kachel {

    public interface IKachel<T> where T : IKartenelement {
        T Kartenelement { get; set; }
    }
}

