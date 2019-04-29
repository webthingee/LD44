using FMODUnity;
using UnityEngine;

public class MainMusic : MonoBehaviour
{
    [EventRef] public string mainMusicSelection;
    private FMOD.Studio.EventInstance mainMusicEvent;

    public float songSelectionValue;
    
    void Start()
    {
        mainMusicEvent = RuntimeManager.CreateInstance(mainMusicSelection);
        mainMusicEvent.setParameterByName("SongSelection", 0, true);
        mainMusicEvent.start();
    }

    void Update()
    {
        mainMusicEvent.setParameterByName("SongSelection", songSelectionValue, true);
    }
}