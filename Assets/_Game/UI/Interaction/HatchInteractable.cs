using System.Collections;
using UnityEngine;

public class HatchInteractable : Interactable
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

            

            GetComponent<SpriteRenderer>().color = Color.green;
            door.GetComponent<SpriteRenderer>().color = Color.green;

            StartCoroutine(StartCutScene());

        }
    }

    public IEnumerator StartCutScene()
    {
        Debug.Log("Playing Cutscene...");
        yield return new WaitForSeconds(2f);
        ReturnFromCutScene();
    }

    public void ReturnFromCutScene()
    {
        Camera.main.transform.position = Vector3.back * 10;
        FindObjectOfType<PlayerPower>().transform.position = destination.transform.position;
        FindObjectOfType<PlayerMovement>().gotoFloorPoint = destination.transform.position;
    }
}
