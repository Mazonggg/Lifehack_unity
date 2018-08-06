
using UnityEngine;
using Lifehack.Model.Prozess;
using UnityEngine.UI;
using Lifehack.Model;
using Lifehack.Spiel.Gui.Popup;
using Lifehack.Spiel.Gui.Form.InputAdapter;

namespace Lifehack.Spiel.Gui.Form.Model.Prozess {

    public class TeilaufgabeFormAdapter : FormAdapter<Teilaufgabe> {

        public GameObject anspracheText, antwortText, erfuellungsText, scheiternText, auswahlButton, dialogContainer, auswahlContainer;

        protected override void InitForm() {
            this.anspracheText.GetComponentsInChildren<Text>()[1].text = this.Eintrag.Dialog.AnspracheText;
            this.antwortText.GetComponentsInChildren<Text>()[1].text = this.Eintrag.Dialog.AntwortText;
            this.erfuellungsText.GetComponentsInChildren<Text>()[1].text = this.Eintrag.Dialog.ErfuellungsText;
            this.scheiternText.GetComponentsInChildren<Text>()[1].text = this.Eintrag.Dialog.ScheiternText;
            this.auswahlButton.GetComponent<Button>().onClick.AddListener(this.AuswahlOeffnen);
        }

        void AuswahlOeffnen() {
            foreach (Item item in ModelHandler.Instance.ItemsInBesitz) {
                GameObject itemEintrag = FormModulAdapter.Instance.GetComponent<InputFabrik>().ErzeugeFormInput(item);
                itemEintrag.transform.SetParent(auswahlContainer.transform);
            }
            PopupModulAdapter.Instance.SetzeTitel("Benötigtes Item auswählen");
            this.WechselInhalt(false);
        }

        public void WaehleItem(Item item) {
            PopupModulAdapter.Instance.SetzeTitel(this.GetPopupTitel());
            this.WechselInhalt(true);
            this.ZeigeAbschlussAn(ModelHandler.Instance.SchliesseTeilaufgabeAb(this.Eintrag, item));
        }

        void ZeigeAbschlussAn(bool istErfolgreich) {
            this.anspracheText.SetActive(false);
            this.antwortText.SetActive(false);
            this.erfuellungsText.SetActive(istErfolgreich);
            this.scheiternText.SetActive(!istErfolgreich);
            this.auswahlButton.SetActive(!istErfolgreich);
        }

        void WechselInhalt(bool dialogAn) {
            this.dialogContainer.SetActive(dialogAn);
            this.auswahlContainer.SetActive(!dialogAn);
            if (dialogAn) {
                foreach (Transform child in this.auswahlContainer.transform) {
                    Destroy(child.gameObject);
                }
            }
        }

        public override string GetPopupTitel() {
            return this.Eintrag.Dialog.MenueText;
        }
    }
}

