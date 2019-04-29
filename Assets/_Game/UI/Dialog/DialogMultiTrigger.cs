using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogMultiTrigger : MonoBehaviour
{
    [TextArea] public string[] dialog;
    public int[] characterNum;
    public bool wasSaid;
    public bool stopPlayer;
    public bool isSpeaking;

    public float songChange = 999;

    public DialogMaster dm;
    
    private void Start()
    {
        wasSaid = false;
        dm = FindObjectOfType<DialogMaster>();
    }

    IEnumerator Say()
    {
        wasSaid = true;

        while (isSpeaking)
        {
            for (int i = 0; i < dialog.Length; i++)
            {
                if (isSpeaking)
                {
                    yield return StartCoroutine(dm.Say(dialog[i], characterNum[i]));
                    dm.CloseDialog();
                    if (i == dialog.Length - 1)
                    {
                        isSpeaking = false;
                    }
                }
            }
        }
        
        dm.CloseDialog();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        dm.CloseDialog();
        
        if (wasSaid) return;
        
        foreach (var v in FindObjectsOfType<DialogMultiTrigger>())
        {
            v.isSpeaking = false;
        }
        
        isSpeaking = true;

        if (songChange < 12) FindObjectOfType<MainMusic>().songSelectionValue = songChange;

        StartCoroutine(Say());

        if (stopPlayer)
        {
            FindObjectOfType<PlayerMovement>().gotoFloorPoint = FindObjectOfType<PlayerMovement>().transform.position;
        }
    }
}
