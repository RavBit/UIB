using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class System_Manager : MonoBehaviour {
    public Text usernameTag;
    public GameObject MapCanvas;
    public GameObject LockScreen;
    void Awake()
    {
        setup();
    }

    void setup()
    {
        Event_Manager.GameLock += Locked;
        string _username = App_Manager.instance.GetUsername;
        if (_username != null)
            usernameTag.text = "" + _username;
        if (_username == null)
            Debug.LogError("Login failed! Please sign in again!");
            
    }

    void Locked()
    {
        LockScreen.SetActive(true);
    }
    public void Logout()
    {
        App_Manager.instance.LogOutUser();
    }
    public void ToggleMap(bool toggle) {
        MapCanvas.SetActive(toggle);
    }
}
