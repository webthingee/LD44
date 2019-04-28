using System.Collections;
using MyEvents;
using UnityEngine;

public class FinalPlugInteractable : Interactable
{
    public GameObject door;
    public GameObject destination;
    
    protected override void PowerLevelCheck()
    {
        Debug.Log("powerCheck");
        if (FindObjectOfType<PlayerPower>().PlayerPowerLevel >= powerReqiured)
        {
            inProgress = false;
            isUnlocked = true;
            FindObjectOfType<PlayerPower>().PlayerPowerLevel -= powerReqiured;
            FindObjectOfType<PlayerFlight>().inFlight = false;

            GetComponent<SpriteRenderer>().color = Color.green;

            StartCoroutine(StartCutScene());

        }
    }

    public IEnumerator StartCutScene()
    {

        Debug.Log("Playing Cutscene...");
        
        CutSceneInfo OnStartCutScene = new CutSceneInfo
        {
            description = "This a cut scene from the Charging Room", 
            obj = gameObject,
            cutSceneName = "Charging Room"
        };
        OnStartCutScene.FireEvent();
        
        cutSceneInProgress = true;

        yield return new WaitForSeconds(0.25f);
        
        Debug.Log("Final...");
    }

    public void ReturnFromCutScene()
    {
        //Debug.Log("Final...");
    }
}