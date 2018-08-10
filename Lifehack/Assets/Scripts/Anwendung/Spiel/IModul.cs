
using System.Collections.Generic;
using Lifehack.Model;

namespace Lifehack.Anwendung.Spiel {

    public interface IModul {
        void SchliesseModul();
        void OeffneModul();
    }

    public interface IModul<T> : IModul where T : IDatenbankEintrag {
        void GetInhalt(List<T> eintraege);
    }
}

