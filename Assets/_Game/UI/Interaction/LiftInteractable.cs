using System.Collections;
using UnityEngine;

public class LiftInteractable : Interactable
{
    public GameObject lift;
    public GameObject otherDoor;
    
    protected override void PowerLevelCheck()
    {
        if (FindObjectOfType<PlayerPower>().PlayerPowerLevel >= powerReqiured)
            {
                inProgress = false;
                isUnlocked = true;
                FindObjectOfType<PlayerPower>().PlayerPowerLevel -= powerReqiured;
                
                GetComponent<SpriteRenderer>().color = Color.green;
                lift.GetComponent<LiftMover>().moveLift = true;

                StartCoroutine(StartCutScene());
            }
    }
    
    public IEnumerator StartCutScene()
    {
        Debug.Log("Playing Cutscene...");
        yield return new WaitForSeconds(1f);
        ReturnFromCutScene();
    }
    
    public void ReturnFromCutScene()
    {
        Debug.Log("done");
    }
}
