using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DisplayMountShip : MonoBehaviour
{
    private InputManager inputManager;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private ChangeActionMap changeActionMap;
    [SerializeField] private PlanetaryGravityBody planetaryGravityBody;
    [SerializeField] private Canvas popUpMount = null;
    [SerializeField] private GameObject shipCam = null;
    [SerializeField] private PlayerSpaceController shipControls = null;
    [SerializeField] private GameObject player = null;
    [SerializeField] private Transform playerPop = null;
    [SerializeField] private BasicInventory inventory;
    

    private bool isOnDetect = false;
    private bool inShip = false;


    private void Start()
    {
        inputManager = InputManager.GetInstance();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            popUpMount.enabled = true;
            isOnDetect = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            popUpMount.enabled = false;
            isOnDetect = false;
        }
    }

    public void MountShip()
    {
        if(!isOnDetect) { return; }
        if(inventory.HaveFuel < 5) { return; }
        
        inventory.RemoveFuel(5);
        player.SetActive(false);
        shipCam.SetActive(true);
        shipControls.enabled = true;
        playerInput.SwitchCurrentActionMap("SpacePlayer");

        inShip = true;
        
    }

    public void DismountShip()
    {
        if(!inShip) { return; }

        player.transform.position = playerPop.position;
        player.SetActive(true);
        shipCam.SetActive(false);
        shipControls.enabled = false;
        playerInput.SwitchCurrentActionMap("SpacePlayer");
        if(!changeActionMap.InAttration)
        {
            planetaryGravityBody.attractor = null;
        }

        inShip = false;

        
    }
}
