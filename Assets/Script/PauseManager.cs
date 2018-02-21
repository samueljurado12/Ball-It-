using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {

    public Text pauseText;

    private bool isPaused;

	// Use this for initialization
	void Start () {
        isPaused = false;
        pauseText.enabled = isPaused;
	}
	
	// Update is called once per frame
	void Update () {
        pauseUnpause();
        pauseText.enabled = isPaused;

    }

    private void pauseUnpause() {
        if (Input.GetButtonDown("Pause") && !isPaused) {
            Debug.Log("paused");
            Time.timeScale = 0;
            isPaused = true;
        } else if (Input.GetButtonDown("Pause") && isPaused) {
            Debug.Log("unpaused");
            Time.timeScale = 1;
            isPaused = false;
        }
    }
}
