using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsTabController : MonoBehaviour
{
    [Space, Header("All Settings Canvas")]
    [SerializeField] private Canvas SoundCanvas;
    [SerializeField] private Canvas ResolutionCanvas;
    [SerializeField] private Canvas ControlsCanvas;


    private void Awake()
    {
        SoundCanvas.enabled = true;
        ResolutionCanvas.enabled = false;
        ControlsCanvas.enabled = false;
    }

    public void ShowSoundSettings()
    {
        SoundCanvas.enabled = true;

        ResolutionCanvas.enabled = false;
        ControlsCanvas.enabled = false;
    }

    public void ShowResolutionSettings()
    {
        ResolutionCanvas.enabled = true;

        SoundCanvas.enabled = false;
        ControlsCanvas.enabled = false;
    }

    public void ShowControlsSettings()
    {
        ControlsCanvas.enabled = true;

        SoundCanvas.enabled = false;
        ResolutionCanvas.enabled = false;
    }
}
