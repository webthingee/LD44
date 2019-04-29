using System.Collections;
using FMODUnity;
using UnityEngine;

public class DrawBridgeInteractable : Interactable
{
    public GameObject target;
    public GameObject destination;
    
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
            
            target.transform.position = destination.transform.position;
            target.transform.rotation = destination.transform.rotation;
            
            FindObjectOfType<PlayerMovement>().gotoFloorPoint = FindObjectOfType<PlayerMovement>().transform.position;
        }
    }
}