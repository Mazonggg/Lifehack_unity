
using Lifehack.Model;
using Lifehack.Model.Einrichtung;
using Lifehack.Model.Prozess;
using Lifehack.Model.Stadtplan;
using Lifehack.Spiel.GuiModul.Form.Model.Einrichtung;
using Lifehack.Spiel.GuiModul.Form.Model.Prozess;
using UnityEngine;

namespace Lifehack.Spiel.GuiModul.Form {

    public class FormFabrik : MonoBehaviour {

        public GameObject
        itemFormPrefab,
        institutFormPrefab,
        aufgabeFormPrefab,
        teilaufgabeFormPrefab,
        niederlassungFormPrefab,
        gebaeudeFormPrefab;

        public GameObject ErzeugeForm(IDatenbankEintrag datenbankEintrag) {
            GameObject form = null;
            if (typeof(Aufgabe).IsAssignableFrom(datenbankEintrag.GetType())) {
                form = Instantiate(aufgabeFormPrefab);
                form.GetComponent<AufgabeForm>().Eintrag = (Aufgabe)datenbankEintrag;
            } else if (typeof(Teilaufgabe).IsAssignableFrom(datenbankEintrag.GetType())) {
                form = Instantiate(teilaufgabeFormPrefab);
                form.GetComponent<TeilaufgabeForm>().Eintrag = (Teilaufgabe)datenbankEintrag;
            } else if (typeof(Item).IsAssignableFrom(datenbankEintrag.GetType())) {
                form = Instantiate(itemFormPrefab);
                form.GetComponent<ItemForm>().Eintrag = (Item)datenbankEintrag;
            } else if (typeof(Institut).IsAssignableFrom(datenbankEintrag.GetType())) {
                form = Instantiate(institutFormPrefab);
                form.GetComponent<InstitutForm>().Eintrag = (Institut)datenbankEintrag;
            } else if (typeof(Niederlassung).IsAssignableFrom(datenbankEintrag.GetType())) {
                form = Instantiate(niederlassungFormPrefab);
                form.GetComponent<NiederlassungForm>().Eintrag = (Niederlassung)datenbankEintrag;
            } else if (typeof(Gebaeude).IsAssignableFrom(datenbankEintrag.GetType())) {
                form = Instantiate(gebaeudeFormPrefab);
            }
            return form;
        }
    }
}

