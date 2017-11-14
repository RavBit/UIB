using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class System_Manager : MonoBehaviour {
    public Text usernameTag;
    void Awake()
    {
        setup();
    }

    void setup()
    {
        string _username = App_Manager.instance.GetUsername;
        if (_username != null)
            usernameTag.text = "" + _username;
        if (_username == null)
            Debug.LogError("Login failed! Please sign in again!");
    }
    public void Logout()
    {
        App_Manager.instance.LogOutUser();
    }
}
