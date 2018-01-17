using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;

/* Clues need to:
 * Always face the camera
 * Be clickable to inspect
 * Each have their own text when inspected
 */

public class ClueScript : MonoBehaviour {

    private Text[] texts;
    public Text clueName, description;
    public Transform target;
    public ClueModel clueModel;
    private Quest_Clues clueData;
    private GameObject objectTarget;
    public Sprite clueSprite;
    public int id;

    void Start() {
        target = GameObject.FindWithTag("MainCamera").gameObject.transform;
        texts = ClueDisplay.canvas.GetComponentsInChildren<Text>();
        clueName = texts[0];
        description = texts[1];
        clueModel = ClueDisplay.canvas.GetComponentInChildren<ClueModel>();
        Debug.Log("Cluemodel " + clueModel.name);
    }

    void Update() {
        //Make sure clue is always facing camera (target)
        transform.LookAt(target);
    }

    void OnMouseOver() {

        //set this clue to found and make it invisible
        List<Quest_Clues> QC = Event_Manager.Get_Clues();
        foreach(Quest_Clues Clues in QC) {
            if(clueName.text == Clues.clue) {
                Clues.found = 1;
            }
        }
        clueData.found = 1;
        gameObject.SetActive(false);
        //activate ClueCanvas
        ClueDisplay.canvas.SetActive(true);
        clueModel.SetModel(id);
        clueName.text = clueData.clue;
        description.text = clueData.description;
    }

    public void Display(Quest_Clues entry) {
        if (entry.found == 1) {
            gameObject.SetActive(false);
        }
        clueData = entry;
       
    }
}