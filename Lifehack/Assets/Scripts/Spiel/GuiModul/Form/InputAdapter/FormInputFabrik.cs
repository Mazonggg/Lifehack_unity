
using Lifehack.Model;
using Lifehack.Model.Prozess;
using UnityEngine;
using UnityEngine.UI;
using Lifehack.Spiel.GuiModul.Form.InputAdapter.Model.Prozess;

namespace Lifehack.Spiel.GuiModul.Form.InputAdapter {

    public class FormInputFabrik : MonoBehaviour {

        public GameObject formInputPrefab;

        public GameObject ErzeugeFormInput(IDatenbankEintrag datenbankEintrag) {
            var formInput = Instantiate(this.formInputPrefab);
            this.ErzeugeFormInputButton(formInput, datenbankEintrag);
            return this.SetzeButtonText(formInput);
        }

        void ErzeugeFormInputButton(GameObject popupEintrag, IDatenbankEintrag datenbankEintrag) {
            var popupButton = popupEintrag.transform.GetChild(0).gameObject;
            if (typeof(Teilaufgabe).IsAssignableFrom(datenbankEintrag.GetType())) {
                popupButton.AddComponent<TeilaufgabeFormInput>();
                popupButton.GetComponent<TeilaufgabeFormInput>().Eintrag = (Teilaufgabe)datenbankEintrag;
            } else if (typeof(Item).IsAssignableFrom(datenbankEintrag.GetType())) {
                popupButton.AddComponent<ItemFormInput>();
                popupButton.GetComponent<ItemFormInput>().Eintrag = (Item)datenbankEintrag;
            }
        }

        GameObject SetzeButtonText(GameObject formInput) {
            var inputButton = formInput.transform.GetChild(0).gameObject;
            inputButton.GetComponentInChildren<Text>().text = inputButton.GetComponent<IFormInputAdapter>().GetInputText();
            return formInput;
        }
    }
}

