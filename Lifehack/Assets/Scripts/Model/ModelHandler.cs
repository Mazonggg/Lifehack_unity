
using System.Collections.Generic;
using Lifehack.Model.Einrichtung;
using Lifehack.Model.Fabrik.Einrichtung;
using Lifehack.Model.Fabrik.Stadtplan;
using Lifehack.Model.Prozess;
using Lifehack.Model.Stadtplan;
using Lifehack.SpielEngine.Model.Stadtplan;
using UnityEngine;
using SimpleJSON;
using System;
using Lifehack.Model.Konstanten;
using Lifehack.Model;

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
        get { return this.institute; }
        set { this.institute = value; }
    }
    private Item[] items = new Item[] { };
    public Item[] Items {
        get { return this.items; }
        set { this.items = value; }
    }
    private Aufgabe[] aufgaben = new Aufgabe[] { };
    public Aufgabe[] Aufgaben {
        get { return this.aufgaben; }
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
        this.InitElemente(json[AustauschKonstanten.INFORMATION]);
        int kachelGroesse = 0;
        Int32.TryParse(json[AustauschKonstanten.KONFIGURATION][AustauschKonstanten.KACHEL_GROESSE].Value, out kachelGroesse);
        StadtplanController.Instance.KachelGroesse = kachelGroesse;
        StadtplanController.Instance.InitStadtplan(json[AustauschKonstanten.KARTE]);
    }

    private void InitElemente(JSONNode jsonInformation) {
        this.institute = new DatenbankEintragParser<Institut>().ArrayZuObjekten(jsonInformation[EnumHandler.AlsString(TabellenName.INSTITUT)], InstitutFabrik.Instance());
        this.items = new DatenbankEintragParser<Item>().ArrayZuObjekten(jsonInformation[EnumHandler.AlsString(TabellenName.ITEM)], ItemFabrik.Instance());
        this.aufgaben = new DatenbankEintragParser<Aufgabe>().ArrayZuObjekten(jsonInformation[EnumHandler.AlsString(TabellenName.AUFGABE)], AufgabeFabrik.Instance());

        List<Kartenelement> elemente = new List<Kartenelement>();
        elemente.AddRange(new DatenbankEintragParser<Umwelt>().ArrayZuObjekten(jsonInformation[EnumHandler.AlsString(TabellenName.KARTENELEMENT)], UmweltFabrik.Instance()));
        elemente.AddRange(new DatenbankEintragParser<Gebaeude>().ArrayZuObjekten(jsonInformation[EnumHandler.AlsString(TabellenName.KARTENELEMENT)], GebaeudeFabrik<Gebaeude>.Instance()));
        elemente.AddRange(new DatenbankEintragParser<Wohnhaus>().ArrayZuObjekten(jsonInformation[EnumHandler.AlsString(TabellenName.KARTENELEMENT)], WohnhausFabrik.Instance()));
        elemente.AddRange(new DatenbankEintragParser<Niederlassung>().ArrayZuObjekten(jsonInformation[EnumHandler.AlsString(TabellenName.KARTENELEMENT)], NiederlassungFabrik.Instance()));
        Dictionary<string, Kartenelement> kartenelementTable = new Dictionary<string, Kartenelement>();
        foreach (Kartenelement kartenelement in elemente) {
            kartenelementTable.Add(kartenelement.Identifier, kartenelement);
        }
        this.kartenelemente = kartenelementTable;
    }
}

