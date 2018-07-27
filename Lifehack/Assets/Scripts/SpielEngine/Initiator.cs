using UnityEngine;
using SimpleJSON;
using Lifehack.Austauschformat;
using System;
using Lifehack.Model;
using Lifehack.Spielengine.GuiModul.Stadtplan;

public class Initiator : MonoBehaviour {

    public

    void Start() {
        StartCoroutine(AustauschAbrufer.Instance.FrageJsonAn(this.InitModelHandler));
    }

    private void InitModelHandler(string json) {
        JSONNode jsonNode = JSON.Parse(json);
        ModelHandler.Instance.InitModel(jsonNode);
        this.InitStadtplanController(jsonNode);
    }

    private void InitStadtplanController(JSONNode json) {
        int kachelGroesse = 0;
        Int32.TryParse(json[AustauschKonstanten.KONFIGURATION][AustauschKonstanten.KACHEL_GROESSE].Value, out kachelGroesse);
        StadtplanModulController.Instance.InitStadtplan(json[AustauschKonstanten.KARTE], kachelGroesse);
    }
}

