using UnityEngine;
using System.Collections;

namespace Lifehack.SpielEngine.GuiModul {

    abstract public class SpielModul : ISpielModul {
        abstract public void InitModul();
        abstract public void LeereModul();
    }
}

