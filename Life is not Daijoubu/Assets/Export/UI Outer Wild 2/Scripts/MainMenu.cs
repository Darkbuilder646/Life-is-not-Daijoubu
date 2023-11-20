using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    [Space]
    [Header("UI")]
    [SerializeField] private Canvas mainCanvas;
    [SerializeField] private Canvas buttonCanvas;
    [SerializeField] private CanvasGroup buttonGroup;
    [SerializeField] private Canvas settingCanvas;
    [SerializeField] private CanvasGroup settingsGroup;

    [Space, Header("Tweening")]
    [SerializeField] private float fadeDuration = 1f;


    private void Awake()
    {
        mainCanvas.enabled = true;
        buttonCanvas.enabled = true;
        buttonGroup.alpha = 1f;
        settingCanvas.enabled = false;
        settingsGroup.alpha = 0f;
    }

    public void StartGame()
    {
        StartCoroutine(StartButton());
    }

    public void OpenCloseSettings()
    {
        StartCoroutine(!settingCanvas.enabled ? OpenSettings() : CloseSettings());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator OpenSettings()
    {
        Tween fadeSettings;
        settingCanvas.enabled = true;
        fadeSettings = settingsGroup.DOFade(1f, fadeDuration);
        fadeSettings = buttonGroup.DOFade(0f, fadeDuration);
        yield return fadeSettings.WaitForCompletion();
        buttonCanvas.enabled = false;
    }

    IEnumerator CloseSettings()
    {
        Tween fadeSettings;
        buttonCanvas.enabled = true;
        fadeSettings = settingsGroup.DOFade(0f, fadeDuration);
        fadeSettings = buttonGroup.DOFade(1f, fadeDuration);
        yield return fadeSettings.WaitForCompletion();
        settingCanvas.enabled = false;
    }

    IEnumerator StartButton()
    {
        Tween fadeButton;
        fadeButton = buttonGroup.DOFade(0, fadeDuration);
        yield return fadeButton.WaitForCompletion();
        mainCanvas.enabled = false;
    }
}