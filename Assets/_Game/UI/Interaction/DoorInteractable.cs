using System.Collections;
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
        yield return new WaitForSeconds(1f);
        FindObjectOfType<PlayerPower>().transform.position = otherDoor.transform.position;
        FindObjectOfType<PlayerMovement>().gotoFloorPoint = otherDoor.transform.position;
        yield return new WaitForSeconds(1f);
        ReturnFromCutScene();
    }
    
    public void ReturnFromCutScene()
    {
        Camera.main.transform.position = new Vector3(20f, -4.2f, -10f);
    }
}
