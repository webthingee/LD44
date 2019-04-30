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
    public RawImage cutSceneRawImage;
    
    private GameObject sceneStartedBy;
    private string cutSceneName;
    private int cutSceneNumber;

    public Texture2D[] cutSceneImages;

    public Button mainMenuButton;
    
    private void OnEnable()
    {
        mainMenuButton.enabled = false;
        canvas.SetActive(false);
        CutSceneInfo.RegisterListener(OnCutSceneStarted);
    }

    private void OnCutSceneStarted(CutSceneInfo e)
    {
        sceneStartedBy = e.obj;
        displayText.text = e.description;
        cutSceneName = e.cutSceneName;
        cutSceneNumber = e.cutSceneNumber;
        
        StartCutScene();
    }

    public void StartCutScene()
    {
        canvas.SetActive(true);
        mainMenuButton.gameObject.SetActive(false);

        if (cutSceneName == "Charging Room")
        {
            mainMenuButton.gameObject.SetActive(true);
            FindObjectOfType<MainMusic>().songSelectionValue = 3;

            //do nothing? StartCoroutine(PlayingWinCutScene());
        }
        else if (cutSceneName == "Death")
        {
            mainMenuButton.gameObject.SetActive(true);
            cutSceneNumber = 4;
            //do nothing? StartCoroutine(PlayingWinCutScene());
        }
        
        StartCoroutine(PlayingCutScene(cutSceneNumber));
        
    }
    
    IEnumerator PlayingCutScene(int sceneNum)
    {
        cutSceneRawImage.texture = cutSceneImages[sceneNum];
        
        yield return new WaitForSeconds(5f);

        if (sceneNum >= 3)
        {
            yield return new WaitForSeconds(5f);
            ReturnToMainMenu();
        }
        else
        {
            ReturnToGame();    
        }
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