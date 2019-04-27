using UnityEngine;

public class InteractableTrigger : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!GetComponentInParent<Interactable>().canUse) return;
		
        GetComponentInParent<Interactable>().InUse = true;
        //GetComponentInParent<Interactable>().canUse = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GetComponentInParent<Interactable>().InUse = false;
        GetComponentInParent<Interactable>().canUse = false;
    }
}