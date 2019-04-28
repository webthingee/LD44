using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class DialogMaster : MonoBehaviour
{
    public GameObject dialogPanel;
    public TextMeshProUGUI dialogText;
    public Button dialogNext;

    public bool showNext;

    public IEnumerator Say(string say)
    {
        OpenDialog();
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
    }
    
    public void CloseDialog()
    {
        showNext = true;
        dialogPanel.SetActive(!dialogPanel.activeSelf);
    }
}
