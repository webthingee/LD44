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
        mainMusicEvent.release();
    }

    public void ChangeSongSelection(float songNum)
    {
        mainMusicEvent.setParameterByName("SongSelection", songNum, true);
        songSelectionValue = songNum;
    }

    void Update()
    {
        mainMusicEvent.setParameterByName("SongSelection", songSelectionValue, true);
    }

    void ThreeDeeAttach()
    {
        FMOD.Studio.EventInstance threeDeeEvent = RuntimeManager.CreateInstance("event:/3D/...");
        threeDeeEvent.start();
        RuntimeManager.AttachInstanceToGameObject(threeDeeEvent, transform, transform.GetComponent<Rigidbody>());
        threeDeeEvent.release();
    }

    void Once()
    {
        RuntimeManager.PlayOneShotAttached("event:/SFX/...", gameObject);
        RuntimeManager.PlayOneShot("event:/SFX/...", new Vector3(1f, 1f, 1f));
    }

    private void OnDestroy()
    {
        mainMusicEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}