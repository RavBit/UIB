using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueLoader : MonoBehaviour {

    public const string path = "Clues";

    ClueManager cm;


    void Start() {
        cm = ClueManager.Load(path);

        foreach (Clue clue in cm.clues) {
            print(clue.clueName);
        }
    }

}
