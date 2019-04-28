﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainBG;
    public GameObject OptionsBG;
    public GameObject InstructionsBG;

    private void Start() {
        ShowMain();
    }

    public void LoadGame() {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void ShowInstructions() {
        MainBG.SetActive(false);
        InstructionsBG.SetActive(true);
    }

    public void ShowMain() {
        MainBG.SetActive(true);
        InstructionsBG.SetActive(false);
        OptionsBG.SetActive(false);
    }

    public void ShowOptions() {
        MainBG.SetActive(false);
        OptionsBG.SetActive(true);
    }

    public void QuitToDesktop() {
#if UNITY_EDITOR // If we're in Unity Editor, stop play mode
        if (UnityEditor.EditorApplication.isPlaying == true)
            UnityEditor.EditorApplication.isPlaying = false;
#else // If we are in a built application, quit to desktop
            Application.Quit();
#endif
    }
}