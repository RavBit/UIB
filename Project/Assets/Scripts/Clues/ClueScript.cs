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
        clueData.isFound = true;
        gameObject.SetActive(false);
        ClueManager.canvas.SetActive(true);

        clueName.text = clueData.clueName;
        description.text = clueData.description;
        //activate ClueCanvas
        //set this clue to found
        //save xml file
    }

    public void Display(ClueEntry entry) {
        clueData = entry;
    }
}