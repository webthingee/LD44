using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class FungusTrigger : MonoBehaviour
{
    public Flowchart flowchart;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Flowchart.BroadcastFungusMessage("ABC");
        Debug.Log("ABC");
    }
}
