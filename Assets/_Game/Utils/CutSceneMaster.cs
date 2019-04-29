using System.Collections;
using MyEvents;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutSceneMaster : MonoBehaviour
{
    public GameObject canvas;
    public TextMeshProUGUI displayText;
    private GameObject sceneStartedBy;
    private string cutSceneName;

    public Button mainMenuButton;
    
    private void OnEnable()
    {
        mainMenuButton.enabled = false;
        CutSceneInfo.RegisterListener(OnCutSceneStarted);
    }

    private void OnCutSceneStarted(CutSceneInfo e)
    {
        sceneStartedBy = e.obj;
        displayText.text = e.description;
        cutSceneName = e.cutSceneName;
        
        StartCutScene();
    }

    public void StartCutScene()
    {
        canvas.SetActive(true);

        if (cutSceneName == "Charging Room")
        {
            mainMenuButton.enabled = true;
            //do nothing? StartCoroutine(PlayingWinCutScene());
        }
        else if (cutSceneName == "Death")
        {
            mainMenuButton.enabled = true;
            //do nothing? StartCoroutine(PlayingWinCutScene());
        }
        else
        {
            StartCoroutine(PlayingCutScene());
        }
    }
    
    IEnumerator PlayingCutScene()
    {
        yield return new WaitForSeconds(5f);
        ReturnToGame();
    }
    
    public void ReturnToGame()
    {
        sceneStartedBy.GetComponent<Interactable>().cutSceneInProgress = false;
        canvas.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        canvas.SetActive(false);
        SceneManager.LoadScene(0);
    }
}