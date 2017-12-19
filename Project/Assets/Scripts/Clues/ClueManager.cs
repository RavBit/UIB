using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Event_Manager.CalculateClue += CountClues;
    }

    public void CountClues() {
        List<Quest_Clues> QC = Event_Manager.Get_Clues();
        int questcount = 0;
        foreach (Quest_Clues clue in QC) {
            if (clue.found == 0)
                questcount++;
        }
        int amountlocations =  QC.Count / 2;
    }
}
