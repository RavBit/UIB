using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueDisplay : MonoBehaviour {

    public ClueScript cluePrefab;
    public Save_Manager SM;
    public GameObject MAP;
    public GameObject AR;
    public GameObject popup;
    public GameObject accuseUI;

    private int foundClues = 0;
    private int minimunClues = 0;

    private Text[] texts;
    public Text clueName, description;
    private Button btn;
    public static GameObject canvas;
    void Awake() {
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

        foreach (Quest_Clues clue in SM.ClueDB.clues) {
            ClueScript newClue = Instantiate(cluePrefab) as ClueScript;
            if (clue.found == 1) {
                newClue.gameObject.SetActive(false);
            }
            newClue.transform.SetParent(transform, false);
            float rand1 = Random.Range(-50, 50);
            float rand2 = Random.Range(-50, 50);
            float rand3 = Random.Range(-50, 50);
            newClue.transform.position = transform.position + new Vector3(rand1, rand2, rand3);
            newClue.Display(clue);
        }
    }

    public void CheckClues() {
        foreach (Quest_Clues clue in SM.ClueDB.clues) {
            if (clue.found == 1) {
                foundClues++;
            }
        }
        if (foundClues >= SM.ClueDB.clues.Capacity) {
            canvas.SetActive(true);
            clueName.text = "You've found all clues.";
            description.text = "Go back to the quest overview.";
            texts[2].text = "Back";
            btn.GetComponentInChildren<Button>().onClick.AddListener(OnClickAction);
            foundClues = SM.ClueDB.clues.Capacity;
        }
    }

    void OnClickAction() {
        AR.SetActive(false);
        MAP.SetActive(true);
    }

    public void Accuse() {
        if (foundClues < minimunClues) {
            popup.SetActive(true);
        } else {
            accuseUI.SetActive(true);
        }
    }
}
