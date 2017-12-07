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
    private ClueEntry clueData;
    private GameObject objectTarget;

    void Start() {
        target = GameObject.FindWithTag("MainCamera").gameObject.transform;
        texts = ClueManager.canvas.GetComponentsInChildren<Text>();
        clueName = texts[0];
        description = texts[1];
    }

    void Update() {
        //Make sure clue is always facing camera (target)
        transform.LookAt(target);
    }

    void OnMouseDown() {

        //set this clue to found and make it invisible
        clueData.isFound = true;
        gameObject.SetActive(false);
        //activate ClueCanvas
        ClueManager.canvas.SetActive(true);

        clueName.text = clueData.clueName;
        description.text = clueData.description;
    }

    public void Display(ClueEntry entry) {
        if (entry.isFound) {
            gameObject.SetActive(false);
        }
        clueData = entry;
       
    }
}