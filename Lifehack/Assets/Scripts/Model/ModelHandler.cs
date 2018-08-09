
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
using Lifehack.Model.Fabrik.Prozess;

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
                if (!teilaufgabe.Abgeschlossen) {
                    return teilaufgabe;
                }
            }
            return null;
        }

        List<IKartenelement> kartenelemente;
        public List<IKartenelement> Kartenelemente {
            get { return this.kartenelemente; }
            set { this.kartenelemente = value; }
        }

        public List<IDatenbankEintrag> GetEintraegeFuerTabelle(TabellenName tabelle) {
            var eintraege = new List<IDatenbankEintrag>();
            switch (tabelle) {
                case TabellenName.ITEM:
                    eintraege.AddRange(ModelHandler.Instance.ItemsInBesitz);
                    break;
                case TabellenName.INSTITUT:
                    eintraege.AddRange(ModelHandler.Instance.Institute);
                    break;
                case TabellenName.AUFGABE:
                    eintraege.AddRange(ModelHandler.Instance.Aufgaben);
                    break;
            }
            return eintraege;
        }

        void Start() {
            ModelHandler._instance = this;
            JSONNode jsonInformation = AustauschAbrufer.Instance.Information;
            this.institute = new DatenbankEintragParser<Institut>().ArrayZuObjekten(jsonInformation[EnumHandler.AlsString(TabellenName.INSTITUT)], InstitutFabrik.Instance);
            this.alleItems = new DatenbankEintragParser<Item>().ArrayZuObjekten(jsonInformation[EnumHandler.AlsString(TabellenName.ITEM)], ItemFabrik.Instance);
            this.aufgaben = new DatenbankEintragParser<Aufgabe>().ArrayZuObjekten(jsonInformation[EnumHandler.AlsString(TabellenName.AUFGABE)], AufgabeFabrik.Instance);

            var elemente = new List<IKartenelement>();
            elemente.AddRange(new DatenbankEintragParser<Umwelt>().ArrayZuObjekten(jsonInformation[EnumHandler.AlsString(TabellenName.KARTENELEMENT)], UmweltFabrik.Instance));
            elemente.AddRange(new DatenbankEintragParser<Gebaeude>().ArrayZuObjekten(jsonInformation[EnumHandler.AlsString(TabellenName.KARTENELEMENT)], GebaeudeFabrik<Gebaeude>.Instance));
            elemente.AddRange(new DatenbankEintragParser<Wohnhaus>().ArrayZuObjekten(jsonInformation[EnumHandler.AlsString(TabellenName.KARTENELEMENT)], WohnhausFabrik.Instance));
            elemente.AddRange(new DatenbankEintragParser<Niederlassung>().ArrayZuObjekten(jsonInformation[EnumHandler.AlsString(TabellenName.KARTENELEMENT)], NiederlassungFabrik.Instance));
            this.kartenelemente = elemente;

            this.InitItemsInBesitz(this.alleItems);

            spielContainer.SetActive(true);
        }

        Stack<string> itemNamenInBesitz = new Stack<string>(new[] { "Geburtsurkunde" });
        // Initialisierung eines grundliegenden Ausgangspunktes fuer das Spiel.
        void InitItemsInBesitz(Item[] items) {
            foreach (Item item in items) {
                if (itemNamenInBesitz.Contains(item.Name)) {
                    this.itemsInBesitz.Add(item);
                }
            }
        }

        public Institut GetInstitut(string institutId) {
            foreach (Institut institut in this.institute) {
                if (institut.Id.Equals(institutId)) {
                    return institut;
                }
            }
            return null;
        }

        public Item GetItem(string itemId) {
            foreach (Item item in this.alleItems) {
                if (item.Id.Equals(itemId)) {
                    return item;
                }
            }
            return null;
        }

        public Aufgabe GetAufgabe(string aufgabeId) {
            foreach (Aufgabe aufgabe in this.aufgaben) {
                if (aufgabe.Id.Equals(aufgabeId)) {
                    return aufgabe;
                }
            }
            return null;
        }

        public bool SchliesseTeilaufgabeAb(Teilaufgabe teilaufgabe, Item abgegebenesItem) {
            if (abgegebenesItem.Equals(teilaufgabe.Bedingung)) {
                teilaufgabe.Abgeschlossen = true;
                if (teilaufgabe.TeilaufgabeArt.Equals(TeilaufgabeArt.ITEM_WIRD_ABGEGEBEN)) {
                    this.itemsInBesitz.Remove(teilaufgabe.Bedingung);
                }
                this.itemsInBesitz.Add(teilaufgabe.Belohnung);
                this.SchliesseAufgabeAb(teilaufgabe);
                return true;
            }
            return false;
        }

        private void SchliesseAufgabeAb(Teilaufgabe teilaufgabe) {
            Aufgabe aufgabe = teilaufgabe.Aufgabe;
            Teilaufgabe[] aufgabenTeilaufgabe = aufgabe.Teilaufgaben;
            if (teilaufgabe.Abgeschlossen && aufgabenTeilaufgabe[aufgabenTeilaufgabe.Length - 1].Equals(teilaufgabe)) {
                aufgabe.Status = Status.BEENDET;
            } else if (aufgabenTeilaufgabe[0].Equals(teilaufgabe)) {
                aufgabe.Status = Status.AKTIV;
            }
        }
    }
}

