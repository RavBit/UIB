using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueDisplay : MonoBehaviour {

    public ClueScript cluePrefab;
    public Save_Manager SM;
    
    public void StartDislay () {
        StartCoroutine("Display");
	}
	
	public IEnumerator Display() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }

        yield return new WaitForSeconds(1);

        foreach (Quest_Clues clue in SM.ClueDB.clues) {
            ClueScript newClue = Instantiate(cluePrefab) as ClueScript;
            if (clue.found == 1) {
                newClue.gameObject.SetActive(false);
            }
            newClue.transform.SetParent(transform, false);
            newClue.Display(clue);
        }
    }
    
}
