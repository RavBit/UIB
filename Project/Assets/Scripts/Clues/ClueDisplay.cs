using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueDisplay : MonoBehaviour {

    public ClueScript cluePrefab;
    public Save_Manager SM;

    private Text[] texts;
    public Text clueName, description;
    public static GameObject canvas;
    void Awake() {
        canvas = GameObject.FindWithTag("ClueCanvas");
        texts = canvas.GetComponentsInChildren<Text>();
        clueName = texts[0];
        description = texts[1];
        canvas.SetActive(false);


    }

    public void StartDisplay () {
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

    public void CheckClues() {
        int foundClues = 0;
        foreach (Quest_Clues clue in SM.ClueDB.clues) {
            if (clue.found != 1) {
                foundClues++;
            }
        }
        if (foundClues == SM.ClueDB.clues.Capacity) {
            canvas.SetActive(true);
            clueName.text = "You've found all clues.";
            description.text = "Go back to the quest overview.";
        }
    }
}
