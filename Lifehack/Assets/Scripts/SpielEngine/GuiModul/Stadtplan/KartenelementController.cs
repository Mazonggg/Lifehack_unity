﻿using System.Collections;
using System.Collections.Generic;
using Lifehack.Model.Stadtplan;
using UnityEngine;

namespace Lifehack.Spielengine.GuiModul.Stadtplan {

    public class KartenelementController : MonoBehaviour {

        private IKartenelement kartenelement;
        public IKartenelement Kartenelement {
            set { this.kartenelement = value; }
        }
    }
}
