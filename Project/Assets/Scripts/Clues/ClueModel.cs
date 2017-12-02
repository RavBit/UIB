using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueModel : MonoBehaviour {

	void OnMouseDrag() {
        transform.Rotate(Input.GetAxis("Mouse Y") * 4, -(Input.GetAxis("Mouse X") * 4), 0);
    }
}
