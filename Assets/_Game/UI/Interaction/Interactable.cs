using UnityEngine;

public class Interactable : MonoBehaviour
{
    public int powerReqiured;
    public bool isUnlocked;
    
    public bool canUse;
    [SerializeField] private bool inUse;
    [SerializeField] public bool inProgress;
    
    public bool cutSceneInProgress;

    public bool InUse
    {
        set
        {
            inUse = value;
            if (inProgress && inUse && canUse)
            {
                StartUsingInteractable();
            }
        }
    }

    private void OnMouseDown()
    {
        Debug.Log(name);
        // turn off any currently active or inProgress interactables
        var allInteractables = FindObjectsOfType<Interactable>();
        foreach (var a in allInteractables)
        {
            a.canUse = false;
            a.InUse = false;
        }
    }

    private void OnMouseUp()
    {
        canUse = true;

        if (!inProgress)
        {
            NotInProgress();
        }
    }

    private void NotInProgress()
    {
		Debug.Log("Not In Progress");
    }

    private void StartUsingInteractable()
    {
		Debug.Log("Start Using");
        PowerLevelCheck();
    }

    private void StopUsingInteractable()
    {
        Debug.Log("Stop Using");
    }

    protected virtual void PowerLevelCheck()
    {
        Debug.Log("powerCheck");
        if (FindObjectOfType<PlayerPower>().PlayerPowerLevel >= powerReqiured)
        {
            inProgress = false;
            isUnlocked = true;
            FindObjectOfType<PlayerPower>().PlayerPowerLevel -= powerReqiured;
        }
    }
}