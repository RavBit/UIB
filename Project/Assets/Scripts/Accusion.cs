using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accusion : MonoBehaviour {

    public Suspect_Item suspect;
    public static Accusion ins;
    public GameObject[] susGO;
    public GameObject suspectContainer;
    public GameObject accusationContainer;

    void Awake() {
        ins = this;
        susGO = GameObject.FindGameObjectsWithTag("Suspect");
    }

    void OnEnable() {
        foreach (GameObject obj in susGO) {
            obj.transform.SetParent(accusationContainer.transform);
        }
    }

    public static void SetSuspect(Suspect_Item sus) {
        ins.suspect = sus;
    }
	
    public void MakeAccusion() {
        //check the selected suspect
        //compare to quest data
        //if they are the same, quest completed
        //if not, minimunclues goes up by 2
        //also set the suspect parents back
        foreach (GameObject obj in susGO) {
            obj.transform.SetParent(suspectContainer.transform);
        }
    }
}
