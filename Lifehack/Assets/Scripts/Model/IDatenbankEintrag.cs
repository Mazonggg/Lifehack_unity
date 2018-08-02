using System;
using Lifehack.Model.Konstanten;

namespace Lifehack.Model {

    public interface IDatenbankEintrag {

        string Id { get; set; }
        TabellenName Tabelle();
    }
}
