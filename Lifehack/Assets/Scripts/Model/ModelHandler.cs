
using System.Collections.Generic;
using Lifehack.Model.Einrichtung;
using Lifehack.Model.Fabrik.Einrichtung;
using Lifehack.Model.Fabrik.Stadtplan;
using Lifehack.Model.Prozess;
using Lifehack.Model.Stadtplan;
using UnityEngine;
using SimpleJSON;
using Lifehack.Model.Konstanten;
using Lifehack.Austauschformat;
using System;

namespace Lifehack.Model {

    public class ModelHandler : MonoBehaviour {

        public GameObject spielContainer;

        static ModelHandler _instance;
        public static ModelHandler Instance {
            get { return ModelHandler._instance; }
        }

        Institut[] institute;
        public Institut[] Institute {
            get { return this.institute; }
            set { this.institute = value; }
        }

        public Teilaufgabe[] GetInstitutNaechsteTeilaufgaben(InstitutArt institutArt) {
            var aufgabens = new List<Teilaufgabe>();
            foreach (Aufgabe aufgabe in this.aufgaben) {
                var teilaufgabe = this.NaechsteTeilaugabeInAufgabe(aufgabe);
                if (teilaufgabe != null && teilaufgabe.InstitutArt.Equals(institutArt)) {
                    aufgabens.Add(teilaufgabe);
                }
            }
            return aufgabens.ToArray();
        }

        public Teilaufgabe NaechsteTeilaugabeInAufgabe(Aufgabe aufgabe) {
            foreach (Teilaufgabe teilaufgabe in aufgabe.Teilaufgaben) {
                Debug.Log("Teilaufgabe: " + teilaufgabe.Dialog.MenueText + "\ninstitutArt: " + EnumHandler.AlsString(teilaufgabe.InstitutArt));
                if (!teilaufgabe.Abgeschlossen) {
                    return teilaufgabe;
                }
            }
            return null;
        }

        Item[] alleItems;

        List<Item> itemsInBesitz = new List<Item>();
        public Item[] ItemsInBesitz {
            get { return this.itemsInBesitz.ToArray(); }
        }

        Aufgabe[] aufgaben;
        public Aufgabe[] Aufgaben {
            get { return this.aufgaben; }
            set { this.aufgaben = value; }
        }
        Dictionary<string, Kartenelement> kartenelemente;
        public Dictionary<string, Kartenelement> Kartenelemente {
            get { return this.kartenelemente; }
            set { this.kartenelemente = value; }
        }

        void Start() {
            ModelHandler._instance = this;
            JSONNode jsonInformation = AustauschAbrufer.Instance.Json[AustauschKonstanten.INFORMATION];
            this.institute = new DatenbankEintragParser<Institut>().ArrayZuObjekten(jsonInformation[EnumHandler.AlsString(TabellenName.INSTITUT)], InstitutFabrik.Instance);
            this.alleItems = new DatenbankEintragParser<Item>().ArrayZuObjekten(jsonInformation[EnumHandler.AlsString(TabellenName.ITEM)], ItemFabrik.Instance);
            this.aufgaben = new DatenbankEintragParser<Aufgabe>().ArrayZuObjekten(jsonInformation[EnumHandler.AlsString(TabellenName.AUFGABE)], AufgabeFabrik.Instance);

            var elemente = new List<Kartenelement>();
            elemente.AddRange(new DatenbankEintragParser<Umwelt>().ArrayZuObjekten(jsonInformation[EnumHandler.AlsString(TabellenName.KARTENELEMENT)], UmweltFabrik.Instance));
            elemente.AddRange(new DatenbankEintragParser<Gebaeude>().ArrayZuObjekten(jsonInformation[EnumHandler.AlsString(TabellenName.KARTENELEMENT)], GebaeudeFabrik<Gebaeude>.Instance));
            elemente.AddRange(new DatenbankEintragParser<Wohnhaus>().ArrayZuObjekten(jsonInformation[EnumHandler.AlsString(TabellenName.KARTENELEMENT)], WohnhausFabrik.Instance));
            elemente.AddRange(new DatenbankEintragParser<Niederlassung>().ArrayZuObjekten(jsonInformation[EnumHandler.AlsString(TabellenName.KARTENELEMENT)], NiederlassungFabrik.Instance));
            var kartenelementTable = new Dictionary<string, Kartenelement>();
            foreach (Kartenelement kartenelement in elemente) {
                kartenelementTable.Add(kartenelement.Identifier, kartenelement);
            }
            this.kartenelemente = kartenelementTable;

            this.InitItemsInBesitz(this.alleItems);

            spielContainer.SetActive(true);
        }

        Stack<string> itemNamenInBesitz = new Stack<string>(new[] { "Personalausweis" });
        // Initialisierung eines grundliegenden Ausgangspunktes fuer das Spiel.
        void InitItemsInBesitz(Item[] items) {
            foreach (Item item in items) {
                if (itemNamenInBesitz.Contains(item.Name)) {
                    this.itemsInBesitz.Add(item);
                }
            }
        }

        public Institut GetInstitut(int institutId) {
            foreach (Institut institut in this.institute) {
                if (institut.Id.Equals(institutId)) {
                    return institut;
                }
            }
            return null;
        }

        public Item GetItem(int itemId) {
            foreach (Item item in this.alleItems) {
                if (item.Id.Equals(itemId)) {
                    return item;
                }
            }
            return null;
        }

        public Aufgabe GetAufgabe(int aufgabeId) {
            foreach (Aufgabe aufgabe in this.aufgaben) {
                if (aufgabe.Id.Equals(aufgabeId)) {
                    return aufgabe;
                }
            }
            return null;
        }

        public bool SchliesseTeilaufgabeAb(Teilaufgabe teilaufgabe, Item abgegebenesItem) {
            Debug.Log("SchliesseTeilaufgabeAb:\nbedingung:\n" + teilaufgabe.Bedingung + "\nbelohnung:\n" + teilaufgabe.Belohnung + "\nabgegebenesItem:\n" + abgegebenesItem);
            if (abgegebenesItem.Equals(teilaufgabe.Bedingung)) {
                teilaufgabe.Abgeschlossen = true;
                Debug.Log("true");
                if (teilaufgabe.TeilaufgabeArt.Equals(TeilaufgabeArt.ITEM_WIRD_ABGEGEBEN)) {
                    this.itemsInBesitz.Remove(teilaufgabe.Bedingung);
                }
                this.itemsInBesitz.Add(teilaufgabe.Belohnung);
                return true;
            }
            Debug.Log("false");
            return false;
        }
    }
}

