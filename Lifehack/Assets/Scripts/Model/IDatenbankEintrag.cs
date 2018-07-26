using System;
using Lifehack.Model.Konstanten;

namespace Lifehack.Model {

    public interface IDatenbankEintrag {

        int Id { get; set; }
        TabellenName Tabelle();
    }
}
