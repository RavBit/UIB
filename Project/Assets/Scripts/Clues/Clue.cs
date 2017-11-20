using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Clues need to:
 * Always face the camera
 * Be clickable to inspect
 * Each have their own text when inspected
 */
public class Clue : MonoBehaviour {
    public string clueText;
    public Text targetText;
    public Transform target;
    public Canvas canvas;
    public ClueManager clueManager;

	void Update () {
        //Make sure clue is always facing camera (target)
        transform.LookAt(target);
    }

    void OnMouseDown() {
        canvas.gameObject.SetActive(true);
        gameObject.SetActive(false);
        targetText.text = clueText;
        clueManager.FoundClue(this);
    }
}
