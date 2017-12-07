using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueModel : MonoBehaviour {

	void OnMouseDrag() {
        transform.Rotate(0, -(Input.GetAxis("Mouse X") * 10), 0);
    }
}
