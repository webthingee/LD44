using System.Collections;
using MyEvents;
using TMPro;
using UnityEngine;

public class CutSceneMaster : MonoBehaviour
{
    public GameObject canvas;
    public TextMeshProUGUI displayText;
    private GameObject sceneStartedBy;
   

    private void OnEnable()
    {
        CutSceneInfo.RegisterListener(OnCutSceneStarted);
    }

    private void OnCutSceneStarted(CutSceneInfo e)
    {
        sceneStartedBy = e.obj;
        displayText.text = e.description;
        StartCutScene();
    }

    public void StartCutScene()
    {
        canvas.SetActive(true);
        StartCoroutine(PlayingCutScene());
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
}