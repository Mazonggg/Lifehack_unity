
using System.Collections.Generic;
using Lifehack.Model;

namespace Lifehack.Spiel.Gui {

    public interface IModul {
        void SchliesseModul();
        void OeffneModul();
    }

    public interface IModul<T> : IModul {
        void GetInhalt(List<T> eintraege);
    }
}

