using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public DialogMaster dm;
    
    private void Start()
    {
        dm = FindObjectOfType<DialogMaster>();
        StartCoroutine(Say());
    }

    IEnumerator Say()
    {
        yield return StartCoroutine(dm.Say("Where the *beep* am I?"));
        yield return StartCoroutine(dm.Say("I need a charging station! \n My apps are a huge battery drain."));
        dm.CloseDialog();
    }
}
