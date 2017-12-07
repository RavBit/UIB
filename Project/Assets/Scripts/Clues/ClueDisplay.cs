using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueDisplay : MonoBehaviour {

    public ClueScript cluePrefab;
    
    public ClueManager clueManager;
    
    
    void Start () {
        Display();
	}
	
	public void Display() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
        foreach (ClueEntry clue in ClueManager.ins.ClueDB.clues) {
            ClueScript newClue = Instantiate(cluePrefab) as ClueScript;
            newClue.transform.SetParent(transform, false);
            newClue.Display(clue);
        }
    }
}
