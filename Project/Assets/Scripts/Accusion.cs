using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Accusion : MonoBehaviour {

    public Suspect_Item suspect;
    public GameObject[] susGO;
    public GameObject suspectContainer;
    public GameObject accusationContainer;
    public Text selected;
    public ClueDisplay cd;
    public GameObject popup;
    
    void Awake() {
        susGO = GameObject.FindGameObjectsWithTag("Suspect");
        selected.text = "Current selection: None";
    }

    void OnEnable() {
        foreach (GameObject obj in susGO) {
            obj.transform.SetParent(accusationContainer.transform);
        }
    }

    public void SetSuspect(Suspect_Item sus) {
        suspect = sus;
        selected.text = "Current selection: " + suspect.suspectName;
    }
	
    public void MakeAccusion() {
        popup.SetActive(true);
        Text txt = popup.GetComponentInChildren<Text>();
        //check the selected suspect
        if (suspect.suspectName == "Adrian van Hek") {
            txt.text =  "You've found the culprit! He will be punished for his deeds. Well done, detective!";
            popup.SetActive(true);
        } else {
            //if not, minimunclues goes up by 2
            txt.text = "It seems you've made a wrong conclusion. Find some more clues and try again.";
            cd.AddMinimum();
        }
        //also set the suspect parents back
        foreach (GameObject obj in susGO) {
            obj.transform.SetParent(suspectContainer.transform);
        }
    }
}
