using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayPopUp : MonoBehaviour
{
    private InputManager inputManager;
    [SerializeField] private Canvas popUp = null;
    [SerializeField] private TextMeshProUGUI objetText = null;
    [SerializeField] private string objetName = "";
    [SerializeField] private BasicInventory inventory;
    private bool isOnGisement = false;

    private void Start()
    {
        inputManager = InputManager.GetInstance();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isOnGisement = true;
            objetText.text = objetName.ToString();
            popUp.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isOnGisement = false;
            popUp.enabled = false;
        }
    }

    public void AddItemInInventory()
    {
        if(!isOnGisement) { return; }

        switch (objetName)
        {
            case "Ice":
                inventory.AddIce();
            break;

            case "Wood":
                inventory.AddWood();
            break;

            case "Carbone":
                inventory.AddCarbone();
            break;

            case "Fuel":
                inventory.AddFuel();
            break;
        }
    }

    
}
