
using System.Collections;
using Lifehack.Austauschformat;
using UnityEngine;

namespace Lifehack {

    public class Initiator : MonoBehaviour {

        public GameObject austauschAbrufer, modelHandler, spielContainer;

        private void Start() {
            Debug.Log("Start");
            austauschAbrufer.SetActive(true);
            Debug.Log("austauschAbrufer");
            modelHandler.SetActive(true);
            Debug.Log("modelHandler");
            spielContainer.SetActive(true);
            Debug.Log("spielContainer");
        }
    }
}

