using System;
using Lifehack.Model.Enum;

namespace Lifehack.Model {

    public interface IDatenbankEintrag {

        int Id { get; set; }
        TabellenName Tabelle();
    }
}
