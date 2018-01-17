using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    public bool gameStart;
    public GameObject EndScreen;
    public GameObject timeBar;


    private float time;
    private float seconds;

    // Use this for initialization
    void Start() {
        time = 1800;
    }

    void GameStart() {
        gameStart = true;
    }

    // Update is called once per frame
    void Update() {

        if (gameStart) {
            time -= Time.deltaTime;

            seconds = (int)(time % 60); //Use the euclidean division for the seconds.
            string secondsText = seconds.ToString ();

            if (seconds < 0) {
                return;
            }

            timerText.text = secondsText;
        }
        else {
            timerText.text = "1800";
        }

        if (timerText.text == "0") {
            EndScreen.SetActive(true);
        }

    }
}
