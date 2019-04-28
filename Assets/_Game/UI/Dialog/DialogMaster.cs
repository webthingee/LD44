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
    public Sprite zdSprite;

    public bool showNext;

    public IEnumerator Say(string say, int charNumber = 1)
    {
        OpenDialog();

        dialogPanel.GetComponent<Image>().sprite = charNumber == 1 ? ktSprite : zdSprite;
        
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
