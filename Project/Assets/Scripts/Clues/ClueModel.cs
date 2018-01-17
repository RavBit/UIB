using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueModel : MonoBehaviour {

    //For 3D models: add a mesh renderer and a mesh component
    //void OnMouseDrag() {
    //    transform.Rotate(0, -(Input.GetAxis("Mouse X") * 10), 0);
    //}

    private SpriteRenderer sr;

    void Awake() {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    public void SetModel(Sprite s) {
        sr.sprite = s;
    }
}
