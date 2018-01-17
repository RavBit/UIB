using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueDisplay : MonoBehaviour {

    public ClueScript cluePrefab;
    public GameObject MAP;
    public GameObject AR;
    public GameObject popup;
    public GameObject accuseUI;
    public Clue_Map CM;
    public static ClueDisplay instance;

    private int foundClues = 0;
    private int minimunClues = 2;
    private List<Quest_Clues> clues;

    private bool seenTutorial = false;

    private Text[] texts;
    public Text clueName, description;
    private Button btn;
    public static GameObject canvas;
    void Awake() {
        instance = this;

        canvas = GameObject.FindWithTag("ClueCanvas");
        texts = canvas.GetComponentsInChildren<Text>();
        btn = canvas.GetComponentInChildren<Button>();
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

        foreach (Quest_Clues clue in clues) {
            ClueScript newClue = Instantiate(cluePrefab) as ClueScript;
            if (clue.found == 1) {
                newClue.gameObject.SetActive(false);
            }
            newClue.transform.SetParent(transform, false);
            float rand1 = Random.Range(-50, 50);
            float rand2 = Random.Range(-20, 20);
            float rand3 = Random.Range(20, 50);
            newClue.transform.position = transform.position + new Vector3(rand1, rand2, rand3);
            newClue.Display(clue);
            newClue.id = clue.ID;
        }
    }

    public void CheckClues() {
        clues = Event_Manager.Get_Clues();
        foundClues = 0;
        foreach (Quest_Clues clue in clues) {
            if (clue.found == 1) {
                foundClues++;
                Event_Manager.Set_ClueFound(clue);
            }
        }/*
        if (foundClues >= clues.Count) {
            canvas.SetActive(true);
            clueName.text = "You've found all clues.";
            description.text = "Go back to the quest overview.";
            texts[2].text = "Back";
            btn.GetComponentInChildren<Button>().onClick.AddListener(StopAR);
            foundClues = clues.Count;
        }*/
    }

    public void StopAR() {
        int counter = 0;
        foreach (Quest_Clues clue in CM.clues) {
            if (clue.found == 1) {
                counter++;
            }
        }
        if(counter >= 2) {
            OnlineMaps.instance.RemoveMarker(CM.OMM);
        }
        AR.SetActive(false);
        MAP.SetActive(true);
        Quest_Manager.Load_Quest();
        Debug.Log("TEST");
    }

    public void Accuse() {
        if (foundClues < minimunClues) {
            popup.SetActive(true);
        } else {
            accuseUI.SetActive(true);
        }
    }

    public void LoadClues(List<Quest_Clues> newClues, Clue_Map _CM) {
        CM = _CM;
        clues = newClues;
        StartCoroutine("Display");
    }

    public void StartAR() {
        AR.SetActive(true);
        if (!seenTutorial) {
            canvas.SetActive(true);
        }
        MAP.SetActive(false);
    }

    public void CloseTutorial() {
        seenTutorial = true;
    }

    public void AddMinimum() {
        if (minimunClues < clues.Count) {
            minimunClues += 2;
        } else if (minimunClues >= clues.Count) {
            minimunClues = clues.Count;
        }
    }
    
}
