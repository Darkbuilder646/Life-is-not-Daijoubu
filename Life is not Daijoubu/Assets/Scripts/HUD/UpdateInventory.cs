using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateInventory : MonoBehaviour
{
    [SerializeField] private BasicInventory inventory = null;
    [Space]
    [SerializeField] private TextMeshProUGUI iceItem = null;
    [SerializeField] private TextMeshProUGUI woodItem = null;
    [SerializeField] private TextMeshProUGUI carboneItem = null;
    [SerializeField] private TextMeshProUGUI fuelItem = null;


    private void Start()
    {
        UpdateHUD();
    }

    public void UpdateHUD()
    {
        iceItem.text = "Ice x " + inventory.HaveIce;
        woodItem.text = "Wood x " + inventory.HaveWood;
        carboneItem.text = "Carbone x " + inventory.HaveCarbone;
        fuelItem.text = "Fuel x " + inventory.HaveFuel;
    }

}
