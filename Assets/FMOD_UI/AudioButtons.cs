using UnityEngine;
using UnityEngine.UI;

public class AudioButtons : MonoBehaviour
{
    public Button closeButton;
    public Button quitButton;
    
    private void Start()
    {
        closeButton?.GetComponent<Button>().onClick.AddListener(ToggleActive);
        quitButton?.GetComponent<Button>().onClick.AddListener(QuitGame);
    }

    public void ToggleActive()
    {
        GetComponentInParent<AudioMaster>().ToggleActive();
    }
    
    public void QuitGame() 
    {
        #if UNITY_EDITOR // If we're in Unity Editor, stop play mode
        if (UnityEditor.EditorApplication.isPlaying == true)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        #else
            Application.Quit();
        #endif
    }
}