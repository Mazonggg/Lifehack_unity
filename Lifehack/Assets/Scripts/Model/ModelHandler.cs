
using System.Collections.Generic;
using Lifehack.Model.Einrichtung;
using Lifehack.Model.Fabrik;
using Lifehack.Model.Fabrik.Einrichtung;
using Lifehack.Model.Fabrik.Stadtplan;
using Lifehack.Model.Prozess;
using Lifehack.Model.Stadtplan;
using Lifehack.SpielEngine.Model.Stadtplan;
using UnityEngine;
using SimpleJSON;

public class ModelHandler : MonoBehaviour {

    private static ModelHandler _instance;
    public static ModelHandler Instance {
        get { return ModelHandler._instance; }
    }

    private void Start() {
        ModelHandler._instance = this;
    }

    // TODO entferne Helfer method
    public static void Log(string log) {
        Debug.Log(log);
    }

    private Institut[] institute = new Institut[] { };
    public Institut[] Institute {
        set { this.institute = value; }
    }
    private Item[] items = new Item[] { };
    public Item[] Items {
        set { this.items = value; }
    }
    private Aufgabe[] aufgaben = new Aufgabe[] { };
    public Aufgabe[] Aufgaben {
        set { this.aufgaben = value; }
    }
    private Dictionary<string, Kartenelement> kartenelemente = new Dictionary<string, Kartenelement>();
    public Dictionary<string, Kartenelement> Kartenelemente {
        get { return this.kartenelemente; }
        set { this.kartenelemente = value; }
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
        foreach (Item item in this.items) {
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

    public void InitModel(JSONNode json) {
        this.InitElemente(json["information"]);
        StadtplanController.Instance.InitStadtplan(json["karte"]);
    }

    private void InitElemente(JSONNode jsonInformation) {
        this.institute = new DatenbankEintragDirektor<Institut>().ParseJsonZuObjekten(jsonInformation["institut"], InstitutFabrik.Instance());
        this.items = new DatenbankEintragDirektor<Item>().ParseJsonZuObjekten(jsonInformation["item"], ItemFabrik.Instance());
        this.aufgaben = new DatenbankEintragDirektor<Aufgabe>().ParseJsonZuObjekten(jsonInformation["aufgabe"], AufgabeFabrik.Instance());

        List<Kartenelement> kartenelemente = new List<Kartenelement>();
        kartenelemente.AddRange(new DatenbankEintragDirektor<Umwelt>().ParseJsonZuObjekten(jsonInformation["kartenelement"], UmweltFabrik.Instance()));
        kartenelemente.AddRange(new DatenbankEintragDirektor<Gebaeude>().ParseJsonZuObjekten(jsonInformation["kartenelement"], GebaeudeFabrik<Gebaeude>.Instance()));
        kartenelemente.AddRange(new DatenbankEintragDirektor<Wohnhaus>().ParseJsonZuObjekten(jsonInformation["kartenelement"], WohnhausFabrik.Instance()));
        kartenelemente.AddRange(new DatenbankEintragDirektor<Niederlassung>().ParseJsonZuObjekten(jsonInformation["kartenelement"], NiederlassungFabrik.Instance()));
        Dictionary<string, Kartenelement> kartenelementTable = new Dictionary<string, Kartenelement>();
        foreach (Kartenelement kartenelement in kartenelemente) {
            kartenelementTable.Add(kartenelement.Identifier, kartenelement);
        }
        this.kartenelemente = kartenelementTable;
    }

    public override string ToString() {
        string ret = "\nINSTITUTE: ";
        foreach (Institut institut in this.institute) {
            ret += "\n" + institut.ToString();
        }
        ret += "\nITEMS: ";
        foreach (Item item in this.items) {
            ret += "\n" + item.ToString();
        }
        ret += "\nAUFGABEN: ";
        foreach (Aufgabe aufgabe in this.aufgaben) {
            ret += "\n" + aufgabe.ToString();
        }
        ret += "\nKARTENELEMENT: ";
        foreach (string key in this.kartenelemente.Keys) {
            ret += "\n" + key + "\n" + kartenelemente[key].ToString();
        }
        return ret;
    }
}

