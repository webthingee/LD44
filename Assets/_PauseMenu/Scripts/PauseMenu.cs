using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject menuHolder;
    public GameObject mainBG;
    public GameObject instructionsBG;
    public bool isPaused;

    void Start() {
        // Ensure pause menu is inactive at start
        if (menuHolder.activeInHierarchy) {
            menuHolder.SetActive(false);
            isPaused = false;
        }
    }

    void Update() {
        if (Input.GetButtonUp("Cancel")) {
            if (!isPaused) {
                Pause();
                ShowMainScreen();
            }
            else
                Resume();
        }
    }

    public void Pause() {
        // Setting timescale to 0 prevents audio from playing
        Time.timeScale = 0.000001f;
        menuHolder.SetActive(true);
        isPaused = true;
    }

    public void Resume() {
        Time.timeScale = 1;
        menuHolder.SetActive(false);
        isPaused = false;
    }

    public void ShowMainScreen() {
        mainBG.SetActive(true);
        instructionsBG.SetActive(false);
    }

    public void ShowInstructions() {
        instructionsBG.SetActive(true);
        mainBG.SetActive(false);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void QuitToMenu() {
        Debug.Log("TODO: Will link to main menu when it exists");
    }
}
