using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [TextArea] public string dialog;
    public bool wasSaid;
    public bool stopPlayer;
    public int charNum = 1;

    public DialogMaster dm;
    
    private void Start()
    {
        wasSaid = false;
        dm = FindObjectOfType<DialogMaster>();
    }

    IEnumerator Say()
    {
        wasSaid = true;

        foreach (var v in FindObjectsOfType<DialogMultiTrigger>())
        {
            v.isSpeaking = false;
        }
        
        yield return StartCoroutine(dm.Say(dialog, charNum));
        
        dm.CloseDialog();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        dm.CloseDialog();
        
        if (wasSaid) return;
        
        StartCoroutine(Say());
        
        if (stopPlayer)
        {
            FindObjectOfType<PlayerMovement>().gotoFloorPoint = FindObjectOfType<PlayerMovement>().transform.position;
        }
    }
}
