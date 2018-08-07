
using System.Collections.Generic;
using Lifehack.Model;
using Lifehack.Spiel.Gui.Popup;
using UnityEngine;
using UnityEngine.UI;

namespace Lifehack.Spiel.Gui {

    abstract public class ModulAdapter<T, U> : MonoBehaviour, IModul<T>, IPopupTitelgeber where U : IDatenbankEintrag {

        public GameObject oeffnendesModul, schliessendesModul;

        public GameObject infoEintrag;

        abstract public void LeereInhalt();
        abstract public void GetInhalt(List<T> eintraege);
        abstract public string GetPopupTitel();
        abstract protected GameObject ErzeugeEintragAdapter(U datenbankEintrag);

        public void SchliesseModul() {
            this.schliessendesModul.SetActive(false);
            this.LeereInhalt();
            oeffnendesModul.SetActive(true);
        }

        public void OeffneModul() {
            gameObject.SetActive(true);
        }

        protected List<GameObject> ErzeugeEintragAdapters(List<U> datenbankEintraege) {
            List<GameObject> adapters = new List<GameObject>();
            foreach (var datenbankEintrag in datenbankEintraege) {
                adapters.Add(this.ErzeugeEintragAdapter(datenbankEintrag));
            }
            return adapters;
        }

        public GameObject ErzeugeInfoEintrag(string text) {
            GameObject info = Instantiate(infoEintrag);
            info.GetComponentInChildren<Text>().text = text;
            return info;
        }
    }
}

