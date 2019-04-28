using UnityEngine;

public class GainFlightInteractable : Interactable
{   
    protected override void PowerLevelCheck()
    {
        Debug.Log("powerCheck");
        if (FindObjectOfType<PlayerPower>().PlayerPowerLevel >= powerReqiured)
        {
            inProgress = false;
            isUnlocked = true;

            FindObjectOfType<PlayerFlight>().enabled = true;
            transform.parent.parent = GameObject.FindWithTag("Player").transform;

            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = 0;
            GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>().offset = new Vector2(1f, 0.5f);
            GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>().size = new Vector2(3f, 1f);
        }
    }
}