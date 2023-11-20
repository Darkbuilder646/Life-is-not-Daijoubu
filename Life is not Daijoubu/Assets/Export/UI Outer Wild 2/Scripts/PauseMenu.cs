using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    private InputManager inputManager;

    [Space]
    [Header("UI")]
    [SerializeField] private Canvas pauseMenu;
    [SerializeField] private Canvas buttonCanvas;
    [SerializeField] private CanvasGroup buttonGroup;
    [SerializeField] private Canvas settingsCanvas;
    [SerializeField] private CanvasGroup settingGroup;
    [SerializeField] private Canvas mainMenu;

    [Space, Header("Tweening")]
    [SerializeField] private float fadeDuration = 1f;

    private void Awake()
    {
        pauseMenu.enabled = false;
        buttonCanvas.enabled = false;
        buttonGroup.alpha = 1f;
        settingsCanvas.enabled = false;
        settingGroup.alpha = 0f;
    }

    private void Start()
    {
        inputManager = InputManager.GetInstance();
    }

    public void SetPause()
    {
        
        if(!mainMenu.enabled && !settingsCanvas.enabled) 
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Cursor.visible = true;
        pauseMenu.enabled = true;
        buttonCanvas.enabled = true;
        isPaused = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Cursor.visible = false;
        pauseMenu.enabled = false;
        settingsCanvas.enabled = false;
        isPaused = false;
        Time.timeScale = 1;
    }

    public void OpenCloseSettingsMenu()
    {
        StartCoroutine(!settingsCanvas.enabled ? OpenSettings() : CloseSettings());
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    IEnumerator OpenSettings()
    {
        Tween fadeSettings;
        settingsCanvas.enabled = true;
        fadeSettings = settingGroup.DOFade(1f, fadeDuration).SetUpdate(true);
        fadeSettings = buttonGroup.DOFade(0f, fadeDuration).SetUpdate(true);
        yield return fadeSettings.WaitForCompletion();
        buttonCanvas.enabled = false;
    }

    IEnumerator CloseSettings()
    {
        Tween fadeSettings;
        buttonCanvas.enabled = true;
        fadeSettings = settingGroup.DOFade(0f, fadeDuration).SetUpdate(true);
        fadeSettings = buttonGroup.DOFade(1f, fadeDuration).SetUpdate(true);
        yield return fadeSettings.WaitForCompletion();
        settingsCanvas.enabled = false;
    }

}