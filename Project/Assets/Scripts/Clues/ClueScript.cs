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

    //public Text clueName, isFound, description;
    public Transform target;

    void Start() {
        target = GameObject.FindWithTag("MainCamera").gameObject.transform;
    }

    void Update() {
        //Make sure clue is always facing camera (target)
        transform.LookAt(target);
    }

    void OnMouseDown() {

        gameObject.SetActive(false);
        //activate ClueCanvas
        //set this clue to found
        //save xml file
    }

    public void Display(ClueEntry entry) {
        Debug.Log(entry.clueName);
        Debug.Log(entry.isFound);
        Debug.Log(entry.description);
        Debug.Log(entry.isKeyClue);
        //clueName.text = entry.clueName;
        //isFound.text = entry.isFound.ToString();
        //description.text = entry.description;
    }
}