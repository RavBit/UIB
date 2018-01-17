using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompareCode : MonoBehaviour {

    public InputField input;
    public GameObject accuse;
    public Text txt;

    public void CheckCode() {
       if (txt.text == "Utrecht" || txt.text == "Mystery" || txt.text == "Detective") {
            accuse.SetActive(true);
        }
    }
}
