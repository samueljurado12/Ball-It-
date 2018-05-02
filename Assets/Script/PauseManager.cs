using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {

    public Text pauseText;
    public GameObject exitToMenu;

    public LevelManager levelManager;

    public EventSystem eventSystem;

    private bool isPaused;
    private Button exitButton;
    private Text exitText;

	// Use this for initialization
	void Start () {
        isPaused = false;
        exitButton = exitToMenu.GetComponent<Button>();
        exitText = exitToMenu.GetComponent<Text>();
        pauseText.enabled = isPaused;
        exitButton.enabled = isPaused;
        exitText.enabled = isPaused;
	}
	
	// Update is called once per frame
	void Update () {
        pauseUnpause();
        pauseText.enabled = isPaused;
        exitButton.enabled = isPaused;
        exitText.enabled = isPaused;
    }

    private void pauseUnpause() {
        if (Input.GetButtonDown("Pause") && !isPaused) {
            Time.timeScale = 0;
            isPaused = true;
            eventSystem.SetSelectedGameObject(exitToMenu);
        } else if (Input.GetButtonDown("Pause") && isPaused) {
            isPaused = false;
            Time.timeScale = 1;
        }
    }

    public void toMainMenu() {
        levelManager.LoadLevel("01_MainMenu");
        Time.timeScale = 1;
    }
}
