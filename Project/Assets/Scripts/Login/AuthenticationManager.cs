﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class AuthenticationManager : MonoBehaviour {
    public GameObject mainMenu;

    public GameObject fieldEmailAddress;
    public GameObject fieldPassword;
    public GameObject fieldReenterPassword;

    public Text textEmail;
    public Text textPassword;
    public Text ReenterPassword;

    public bool ShowRegister = false;
    public Text RegisterText;

    public Text Login_Feedback;

    WWWForm form;
    // Use this for initialization
    public class User {
        public bool success;
        public string error;
        public string email;
        public int id;
        // feel free to add userName....
    }
    void Start () {
        Login_Feedback.text = "";

    }

    public void LoginButtonTapped()
    {
        Login_Feedback.text = "Logging in...";
        StartCoroutine("RequestLogin");
    }
    public IEnumerator RequestLogin()
    {
        string email = textEmail.text;
        string password = textPassword.GetComponentInParent<InputField>().text;
        form = new WWWForm();
        form.AddField("email", email);
        form.AddField("password", password);

        WWW w = new WWW("http://81.169.177.181/UIB/action_login_1.php", form);
        yield return w;
        Debug.Log("w " + w.text);
        if (string.IsNullOrEmpty(w.error)) {
            User user = JsonUtility.FromJson<User>(w.text);
            if (user.success == true) {
                if (user.error != "") {
                    Login_Feedback.text = user.error;
                } else {
                    Login_Feedback.text = "login successful.";
                }
            } else {
                Login_Feedback.text = "An error occured";
            }

            // todo: launch the game (player)
        } else {
            // error
            Login_Feedback.text = "An error occured.";
        }
        /*if (w.text.ToLower().Contains("invalid email or password"))
        {
            Login_Feedback.text = "Invalid email or password";

        }
        else
        {
            Login_Feedback.text = "Login Successful";
            App_Manager.instance.SetUsername(email);
            SceneManager.LoadScene("Home", LoadSceneMode.Single);
        }
        }
        else
        {
            Login_Feedback.text = "An Error Occured";
        }*/

    }
}
