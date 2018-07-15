using System;

namespace Lifehack.Model {

    public interface IDatenbankEintrag {

        int Id { get; set; }
        T Tabelle<T>() where T : struct, IConvertible;
    }
}

