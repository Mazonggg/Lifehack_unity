
using UnityEngine;
using UnityEngine.UI;

namespace Lifehack.Spiel.GuiModul.Popup.PopupEintragAdapter {

    public class PopupEintragController : MonoBehaviour {

        private IPopupEintragAdapter eintragAdapter;
        private GameObject viewport;

        public void InitPopupEintragController(IPopupEintragAdapter eintragAdapter) {
            viewport = gameObject.transform.parent.gameObject;
            this.eintragAdapter = eintragAdapter;
            Button button = GetComponent<Button>();
            GetComponentInChildren<Text>().text = this.eintragAdapter.GetPopupEintragText();
            gameObject.transform.SetParent(viewport.transform);
            button.onClick.AddListener(this.OeffneInfo);
        }

        private void OeffneInfo() {
            Debug.Log("OeffneInfo: " + this.eintragAdapter.GetPopupEintragText());
        }
    }
}

