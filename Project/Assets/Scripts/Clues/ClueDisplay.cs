using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueDisplay : MonoBehaviour {

    public ClueScript cluePrefab;
    
    void Start () {
        StartCoroutine("Display");
	}
	
	public IEnumerator Display() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }

        yield return new WaitForSeconds(1);

        foreach (ClueEntry clue in ClueManager.ins.ClueDB.clues) {
            ClueScript newClue = Instantiate(cluePrefab) as ClueScript;
            if (clue.isFound) {
                newClue.gameObject.SetActive(false);
            }
            newClue.transform.SetParent(transform, false);
            newClue.Display(clue);
        }
    }
    
}
