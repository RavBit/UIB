using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class AR_Check : MonoBehaviour {

    // Use this for initialization
    void Update() {

        if(GetComponent<VuforiaBehaviour>() != null)
            Destroy(GetComponent<VuforiaBehaviour>());
    }
}
