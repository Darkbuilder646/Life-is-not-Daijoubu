using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class InitGame : MonoBehaviour
{
    [SerializeField] private GameObject GravityModifier;
    [SerializeField] private GameObject playerCam;
    [SerializeField] private PlayerInput playerInput;

    [Space, Header("Tweening")]
    [SerializeField] private float moveDuration = 1f;



    public CapsuleCollider capsuleColliderPlayer;
    public GameObject mainMenuCam;


    private void Awake()
    {
        playerInput.defaultActionMap = "GroundPlayer";
        capsuleColliderPlayer.enabled = false;
        GravityModifier.SetActive(false);
        mainMenuCam.SetActive(true);
        playerCam.SetActive(false);
    }

    public void Init()
    {
        StartCoroutine(MoveCam());
    }

    IEnumerator MoveCam()
    {
        Tween CamMoving;
        CamMoving = mainMenuCam.transform.DOMove(playerCam.transform.position, moveDuration, false).SetEase(Ease.Linear);
        CamMoving = mainMenuCam.transform.DORotate(new Vector3(14.582f, -90, 0f), moveDuration, RotateMode.Fast).SetEase(Ease.Linear);
        yield return CamMoving.WaitForCompletion();

        mainMenuCam.SetActive(false);
        playerCam.SetActive(true);
        GravityModifier.SetActive(true);
        capsuleColliderPlayer.enabled = true;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }


}
