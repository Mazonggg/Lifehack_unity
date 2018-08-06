
using Lifehack.Model;
using Lifehack.Model.Einrichtung;
using Lifehack.Model.Prozess;
using Lifehack.Model.Stadtplan;
using Lifehack.Spiel.Gui.Form.Model.Einrichtung;
using Lifehack.Spiel.Gui.Form.Model.Prozess;
using UnityEngine;

namespace Lifehack.Spiel.Gui.Form {

    public class SimpleFormFabrik : MonoBehaviour {

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
                form.GetComponent<AufgabeFormAdapter>().Eintrag = (Aufgabe)datenbankEintrag;
            } else if (typeof(Teilaufgabe).IsAssignableFrom(datenbankEintrag.GetType())) {
                form = Instantiate(teilaufgabeFormPrefab);
                form.GetComponent<TeilaufgabeFormAdapter>().Eintrag = (Teilaufgabe)datenbankEintrag;
            } else if (typeof(Item).IsAssignableFrom(datenbankEintrag.GetType())) {
                form = Instantiate(itemFormPrefab);
                form.GetComponent<ItemFormAdapter>().Eintrag = (Item)datenbankEintrag;
            } else if (typeof(Institut).IsAssignableFrom(datenbankEintrag.GetType())) {
                form = Instantiate(institutFormPrefab);
                form.GetComponent<InstitutFormAdapter>().Eintrag = (Institut)datenbankEintrag;
            } else if (typeof(Niederlassung).IsAssignableFrom(datenbankEintrag.GetType())) {
                form = Instantiate(niederlassungFormPrefab);
                form.GetComponent<NiederlassungFormAdapter>().Eintrag = (Niederlassung)datenbankEintrag;
            } else if (typeof(Gebaeude).IsAssignableFrom(datenbankEintrag.GetType())) {
                form = Instantiate(gebaeudeFormPrefab);
            }
            return form;
        }
    }
}

