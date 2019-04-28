using System.Collections;
using MyEvents;
using UnityEngine;

public class DoorInteractable : Interactable
{
    public GameObject door;
    public GameObject otherDoor;
    
    protected override void PowerLevelCheck()
    {
        if (otherDoor == null)
        {
            if (FindObjectOfType<PlayerPower>().PlayerPowerLevel >= powerReqiured)
            {
                inProgress = false;
                isUnlocked = true;
                FindObjectOfType<PlayerPower>().PlayerPowerLevel -= powerReqiured;

            

                GetComponent<SpriteRenderer>().color = Color.green;
                door.GetComponent<SpriteRenderer>().color = Color.green;

                door.GetComponent<DoorInteractable>().canUse = true;
            }
        }
        else
        {
            StartCoroutine(StartCutScene());
        }
    }
    
    public IEnumerator StartCutScene()
    {
        Debug.Log("Playing Cutscene...");
        
        CutSceneInfo OnStartCutScene = new CutSceneInfo
        {
            description = "This a cut scene from the Door", 
            obj = gameObject,
            cutSceneName = "Door"
        };
        OnStartCutScene.FireEvent();
        
        cutSceneInProgress = true;

        yield return new WaitForSeconds(0.25f);
        
        Camera.main.transform.position = new Vector3(20f, -4.2f, -10f);
        FindObjectOfType<PlayerPower>().transform.position = otherDoor.transform.position;
        FindObjectOfType<PlayerMovement>().gotoFloorPoint = otherDoor.transform.position;

        while (cutSceneInProgress)
        {
            yield return new WaitForSeconds(1f);
        }
        
        yield return new WaitForSeconds(0.1f);
        
        //ReturnFromCutScene();
    }
    
    public void ReturnFromCutScene()
    {
    }
}
