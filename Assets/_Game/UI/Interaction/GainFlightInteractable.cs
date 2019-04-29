using System.Collections;
using UnityEngine;

public class GainFlightInteractable : Interactable
{
    public Sprite combined;
    public GameObject hideMe;

    
    protected override void PowerLevelCheck()
    {
        Debug.Log("powerCheck");
        if (FindObjectOfType<PlayerPower>().PlayerPowerLevel >= powerReqiured)
        {
            inProgress = false;
            isUnlocked = true;

            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = 0;
            GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0.6f);
            GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>().size = new Vector2(2f, 1.5f);
            GameObject.FindWithTag("Player").GetComponentInChildren<SpriteRenderer>().sprite = combined;
            
            FindObjectOfType<PlayerFlight>().enabled = true;
            
            hideMe.SetActive(false);
                        
            StartCoroutine(Say());
        }
    }

    public DialogMaster dm;
    
    private void Start()
    {
        dm = FindObjectOfType<DialogMaster>();
    }

    IEnumerator Say()
    {
        yield return StartCoroutine(dm.Say("Oh, uh, pardon me. Excuse me. *ahem* \n This uses a lot of power, gotta get to that door fast."));
        
        transform.parent.parent.gameObject.SetActive(false);
        
        dm.CloseDialog();
    }
}