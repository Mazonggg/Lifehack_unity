using System;

namespace Lifehack.Model.Stadtplan {

    public interface IKartenElement {

        Abmessung[] Abmessungen { get; set; }
        string KartenelementAussehen { get; set; }
    }
}

