using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour {
    public GameObject CluePrefab;
    public Transform ClueContainer;
    List<Quest_Clues> QC = new List<Quest_Clues>();
    public void Display() {
        foreach(Quest_Clues clue in QC) {
            if(clue.found == 1) {
                GameObject cp = Instantiate(CluePrefab, Vector3.zero, Quaternion.identity);
                cp.GetComponent<Backpack_ClueDisplay>().clue.text = clue.clue;
                cp.transform.parent = ClueContainer;
            }
        }
    }

    public void AddClue(Quest_Clues clue) {
        QC.Add(clue);
    }
}
