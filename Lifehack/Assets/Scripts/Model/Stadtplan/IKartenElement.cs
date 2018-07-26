using System;
using Lifehack.Model.Konstanten;

namespace Lifehack.Model.Stadtplan {

    public interface IKartenelement : IDatenbankEintrag {

        string Identifier { get; set; }
        string KartenelementAussehen { get; set; }
        KartenelementArt KartenelementArt { get; }
    }
}

