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
            Debug.Log("asdf");
            FindObjectOfType<PlayerPower>().transform.position = otherDoor.transform.position;
            FindObjectOfType<PlayerMovement>().gotoFloorPoint = otherDoor.transform.position;
            
        }
    }
}
