using System.Collections;
using FMODUnity;
using MyEvents;
using UnityEngine;

public class HatchInteractable : Interactable
{
    public GameObject door;
    public GameObject destination;

    public GameObject[] hideThese;
    public GameObject[] showThese;
    
    [EventRef] public string soundEffect2;
    
    //@TODO pause mouse input?
    
    protected override void PowerLevelCheck()
    {
        Debug.Log("powerCheck");
        if (FindObjectOfType<PlayerPower>().PlayerPowerLevel >= powerReqiured)
        {
            inProgress = false;
            isUnlocked = true;
            FindObjectOfType<PlayerPower>().PlayerPowerLevel -= powerReqiured;

            if (soundEffect != null)
            {
                RuntimeManager.PlayOneShotAttached(soundEffect, gameObject);
            }
            
            GetComponent<SpriteRenderer>().color = Color.green;
            door.GetComponent<SpriteRenderer>().color = Color.green;

            StartCoroutine(StartCutScene());
        }
    }

    public IEnumerator StartCutScene()
    {

        //yield return StartCoroutine(FindObjectOfType<DialogMaster>().Say("What's This?... An Underground Passage?"));
        FindObjectOfType<DialogMaster>().CloseDialog();
        
        Debug.Log("Playing Cutscene...");
        
        CutSceneInfo OnStartCutScene = new CutSceneInfo
        {
            description = "The hatch led to an elevator. \n I wonder how deep underground it goes.", 
            obj = gameObject,
            cutSceneName = "Hatch",
            cutSceneNumber = 1
        };
        OnStartCutScene.FireEvent();
        
        cutSceneInProgress = true;
        
        yield return new WaitForSeconds(4f);
        
        Camera.main.transform.position = Vector3.back * 10;
        
        if (soundEffect2 != null)
        {
            RuntimeManager.PlayOneShotAttached(soundEffect2, gameObject);
        }
        
        yield return new WaitForSeconds(0.5f);

        FindObjectOfType<PlayerPower>().transform.position = destination.transform.position;
        FindObjectOfType<PlayerMovement>().gotoFloorPoint = destination.transform.position;

        foreach (GameObject g in hideThese)
        {
            g.SetActive(false);
        }
        
        foreach (GameObject g in showThese)
        {
            g.SetActive(true);
        }

        while (cutSceneInProgress)
        {
            yield return new WaitForSeconds(0.5f);
        }

        //yield return StartCoroutine(FindObjectOfType<DialogMaster>().Say("This lift looks dead \n Maybe I can charge it"));
        //FindObjectOfType<DialogMaster>().CloseDialog();
        //ReturnFromCutScene();
    }

    public void ReturnFromCutScene()
    {

    }
}
