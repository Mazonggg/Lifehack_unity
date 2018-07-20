using System;
using Lifehack.Model.Enum;

namespace Lifehack.Model.Stadtplan {

    public interface IKartenelement : IDatenbankEintrag {

        Abmessung[] Abmessungen { get; set; }
        string KartenelementAussehen { get; set; }
        KartenelementArt KartenelementArt { get; }
    }
}
