using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Lifehack.GUI.Menue.PopupEintragAdapter {

    public class PopupEintragController : MonoBehaviour {

        private IPopupEintragAdapter eintragAdapter;
        public GameObject viewport;

        public void InitPopupEintragController(IPopupEintragAdapter eintragAdapter) {
            this.eintragAdapter = eintragAdapter;
            Button button = GetComponent<Button>();
            GetComponentInChildren<Text>().text = this.eintragAdapter.GetPopupEintragText();
            gameObject.transform.SetParent(viewport.transform);
            button.onClick.AddListener(this.OeffneInfo);
        }

        private void OeffneInfo() {
        }
    }
}

