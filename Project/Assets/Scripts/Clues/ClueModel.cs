using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueModel : MonoBehaviour {

    //For 3D models: add a mesh renderer and a mesh component
    //void OnMouseDrag() {
    //    transform.Rotate(0, -(Input.GetAxis("Mouse X") * 10), 0);
    //}

    private Image sr;

    void Awake() {
        sr = gameObject.GetComponent<Image>();
        sr.gameObject.SetActive(false);
    }

    public void SetModel(int id) {
        sr.gameObject.SetActive(true);
        string str = id.ToString();
        Sprite s = Resources.Load<Sprite>("Sprites/Clues/" + str);
        sr.sprite = s;
    }
}
