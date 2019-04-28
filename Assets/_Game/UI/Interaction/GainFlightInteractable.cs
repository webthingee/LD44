using System.Collections;
using UnityEngine;

public class GainFlightInteractable : Interactable
{
    //public GameObject door;
    //public GameObject destination;
    
    protected override void PowerLevelCheck()
    {
        Debug.Log("powerCheck");
        if (FindObjectOfType<PlayerPower>().PlayerPowerLevel >= powerReqiured)
        {
            inProgress = false;
            isUnlocked = true;

            FindObjectOfType<PlayerFlight>().enabled = true;
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = 0;

        }
    }
}