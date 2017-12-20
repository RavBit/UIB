using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    [SerializeField]
    public List<Clue_Map> ClueMap;
    // Use this for initialization
    void Start()
    {
        Event_Manager.CalculateClue += CountClues;
    }

    public void CountClues()
    {
        ClueMap = new List<Clue_Map>();
        List<Quest_Clues> QC = Event_Manager.Get_Clues();
        List<Quest_Clues> test = new List<Quest_Clues>();
        foreach (Quest_Clues clue in QC)
        {
            if (clue.found == 0)
            {
                test.Add(clue);
            }
        }
        int startint = 0;
        for (int i = 0; i < test.Count; i++)
        {
            if(i % 2 > 0)
            {
                Debug.Log("STARTCOUNT " + startint + " i" + i);
                Clue_Map CM = new Clue_Map();
                CM.clues = new List<Quest_Clues>();
                CM.clues.AddRange(test.GetRange(startint, 2));
                startint = startint + 2;
                ClueMap.Add(CM);
            }
        }
        Event_Manager.Generate_Clues(ClueMap);
    }
}
