
using System.Collections.Generic;
using Lifehack.Model.Einrichtung;
using Lifehack.Model.Prozess;
using Lifehack.Model.Stadtplan;
using UnityEngine;

public class ModelHandler : MonoBehaviour {

    private static ModelHandler _instance;
    public static ModelHandler Instance {
        get { return ModelHandler._instance; }
    }

    private void Start() {
        ModelHandler._instance = this;
    }

    // TODO Helper method
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

    public Kartenelement GetKartenelement(string identifier) {
        if (this.kartenelemente.ContainsKey(identifier)) {
            return this.kartenelemente[identifier];
        }
        return null;
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

