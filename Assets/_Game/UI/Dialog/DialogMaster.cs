using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogMaster : MonoBehaviour
{
    public GameObject dialogPanel;
    public TextMeshProUGUI dialogText;
    public Sprite ktSprite;

    public bool showNext;

    public IEnumerator Say(string say)
    {
        OpenDialog();

        // may change based on a var passed
        // dialogPanel.GetComponent<Image>().sprite = ktSprite;
        
        dialogText.text = say;

        while (!showNext)
        {
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForEndOfFrame();
    }

    public void OpenDialog()
    {
        dialogPanel.SetActive(true);
        showNext = false;
    }

    public void NextDialog()
    {
        showNext = true;
        dialogPanel.SetActive(false);
    }
    
    public void CloseDialog()
    {
        showNext = true;
        dialogPanel.SetActive(false);
    }
}
