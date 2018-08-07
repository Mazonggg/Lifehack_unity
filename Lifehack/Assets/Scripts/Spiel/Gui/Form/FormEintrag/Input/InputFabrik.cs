
using Lifehack.Model;
using Lifehack.Model.Prozess;
using UnityEngine;
using UnityEngine.UI;
using Lifehack.Spiel.Gui.Form.FormEintrag.Input.Model.Prozess;

namespace Lifehack.Spiel.Gui.Form.FormEintrag.Input {

    public class InputFabrik : MonoBehaviour {

        public GameObject formInputPrefab;

        public GameObject ErzeugeFormInput(IDatenbankEintrag datenbankEintrag) {
            var formInput = Instantiate(this.formInputPrefab);
            this.ErzeugeFormInputButton(formInput, datenbankEintrag);
            return this.SetzeButtonText(formInput);
        }

        void ErzeugeFormInputButton(GameObject popupEintrag, IDatenbankEintrag datenbankEintrag) {
            var popupButton = popupEintrag.transform.GetChild(0).gameObject;
            if (typeof(Teilaufgabe).IsAssignableFrom(datenbankEintrag.GetType())) {
                popupButton.AddComponent<TeilaufgabeInputAdapter>();
                popupButton.GetComponent<TeilaufgabeInputAdapter>().Eintrag = (Teilaufgabe)datenbankEintrag;
            } else if (typeof(Item).IsAssignableFrom(datenbankEintrag.GetType())) {
                popupButton.AddComponent<ItemInputAdapter>();
                popupButton.GetComponent<ItemInputAdapter>().Eintrag = (Item)datenbankEintrag;
            }
        }

        GameObject SetzeButtonText(GameObject formInput) {
            var inputButton = formInput.transform.GetChild(0).gameObject;
            inputButton.GetComponentInChildren<Text>().text = inputButton.GetComponent<IInput>().GetInputText();
            return formInput;
        }
    }
}

