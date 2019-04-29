using System.Collections;
using MyEvents;
using UnityEngine;

public class DoorInteractable : Interactable
{
    public GameObject door;
    public GameObject otherDoor;

    public Interactable setToInProgress;
    
    protected override void PowerLevelCheck()
    {
        if (otherDoor == null)
        {
            if (FindObjectOfType<PlayerPower>().PlayerPowerLevel >= powerReqiured)
            {
                inProgress = false;
                isUnlocked = true;
                FindObjectOfType<PlayerPower>().PlayerPowerLevel -= powerReqiured;

                setToInProgress.inProgress = true;

                Color colorChange = Color.green;
                colorChange.a = 0.11f;

                GetComponent<SpriteRenderer>().color = colorChange;
                door.GetComponent<SpriteRenderer>().color = colorChange;

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
            description = "Scanning ... Scanning ... I detect weapons. \n Maybe I can blast the door open.", 
            obj = gameObject,
            cutSceneName = "Door",
            cutSceneNumber = 2
        };
        OnStartCutScene.FireEvent();
        
        cutSceneInProgress = true;

        yield return new WaitForSeconds(0.25f);
        
        Camera.main.transform.position = new Vector3(19f, -7f, -10f);
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
