using System.Collections;
using MyEvents;
using UnityEngine;

public class HatchInteractable : Interactable
{
    public GameObject door;
    public GameObject destination;
    
    //@TODO pause mouse input
    
    protected override void PowerLevelCheck()
    {
        Debug.Log("powerCheck");
        if (FindObjectOfType<PlayerPower>().PlayerPowerLevel >= powerReqiured)
        {
            inProgress = false;
            isUnlocked = true;
            FindObjectOfType<PlayerPower>().PlayerPowerLevel -= powerReqiured;
            
            GetComponent<SpriteRenderer>().color = Color.green;
            door.GetComponent<SpriteRenderer>().color = Color.green;

            StartCoroutine(StartCutScene());
        }
    }

    public IEnumerator StartCutScene()
    {

        yield return StartCoroutine(FindObjectOfType<DialogMaster>().Say("What's This?... An Underground Passage?"));
        FindObjectOfType<DialogMaster>().CloseDialog();
        
        Debug.Log("Playing Cutscene...");
        
        CutSceneInfo OnStartCutScene = new CutSceneInfo
        {
            description = "This a cut scene from the Hatch", 
            obj = gameObject,
            cutSceneName = "Hatch"
        };
        OnStartCutScene.FireEvent();
        
        cutSceneInProgress = true;
        
        yield return new WaitForSeconds(0.5f);

        Camera.main.transform.position = Vector3.back * 10;
        FindObjectOfType<PlayerPower>().transform.position = destination.transform.position;
        FindObjectOfType<PlayerMovement>().gotoFloorPoint = destination.transform.position;

        while (cutSceneInProgress)
        {
            yield return new WaitForSeconds(0.5f);
        }
        
        yield return StartCoroutine(FindObjectOfType<DialogMaster>().Say("This lift looks dead \n Maybe I can charge it"));
        FindObjectOfType<DialogMaster>().CloseDialog();
        //ReturnFromCutScene();
    }

    public void ReturnFromCutScene()
    {

    }
}
