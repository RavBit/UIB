using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Clue Manager:
 * Manages amount of clues,
 * state of clues,
 * which clues are found.
 */
public class ClueManager : MonoBehaviour {
    private int clueCount;
    private Clue[] cluesArray;
    private List<Clue> cluesList;
    private List<string> foundClues;

	void Start () {
        cluesList = GetComponentsInChildren<Clue>();
        
        for (int i = 0; i < cluesArray.Length; i++) {
            Debug.Log(cluesArray.Length);
            cluesList.Add(cluesArray[i]);
        }
	}

    public void FoundClue(Clue clue) {
        for (int i = 0; i < cluesList.Count; i++) {
            if (cluesList[i].clueText == clue.clueText) {
                foundClues.Add(clue.clueText);
                cluesList.RemoveAt(i);
            }
        }

        if (cluesList.Count <= 0) {
            Debug.Log("All clues have been found.");
        }
    }
}
