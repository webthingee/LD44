using System.Collections;
using System.Collections.Generic;
using MyEvents;
using UnityEngine;

public class WinConditionHelper : MonoBehaviour
{
    public bool pleaseEnd;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (!pleaseEnd) StartCoroutine(StartCutScene());
            pleaseEnd = true;

        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (!pleaseEnd) StartCoroutine(StartCutScene());
            pleaseEnd = true;
        }
    }

    public IEnumerator StartCutScene()
    {

        Debug.Log("Playing Cutscene...");
        
        CutSceneInfo OnStartCutScene = new CutSceneInfo
        {
            description = "", 
            obj = gameObject,
            cutSceneName = "Charging Room",
            cutSceneNumber = 3
        };
        OnStartCutScene.FireEvent();
        
        yield return new WaitForSeconds(0.25f);
        
        Debug.Log("Final...");
    }
    
}
