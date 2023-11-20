using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicInventory : MonoBehaviour
{
    [SerializeField] private UpdateInventory updateInventory;
    [Space, Header("Inventory")]
    [SerializeField] private int haveIce = 0;
    [SerializeField] private int haveWood = 0;
    [SerializeField] private int haveCarbone = 0;
    [SerializeField] private int haveFuel = 50;

    public int HaveIce => haveIce;
    public int HaveWood => haveWood;
    public int HaveCarbone => haveCarbone;
    public int HaveFuel => haveFuel;

    #region Add
    public void AddIce()
    {
        haveIce++;
        updateInventory.UpdateHUD();
    }

    public void AddWood()
    {
        haveWood++;
        updateInventory.UpdateHUD();
    }

    public void AddCarbone()
    {
        haveCarbone++;
        updateInventory.UpdateHUD();
    }

    public void AddFuel()
    {
        haveFuel++;
        updateInventory.UpdateHUD();
    }
    #endregion
    
    #region Remove
    public void RemoveIce(int _number)
    {
        haveIce -= _number;
        updateInventory.UpdateHUD();
    }

    public void RemoveWood(int _number)
    {
        haveWood -= _number;
        updateInventory.UpdateHUD();
    }

    public void RemoveCarbone(int _number)
    {
        haveCarbone -= _number;
        updateInventory.UpdateHUD();
    }

    public void RemoveFuel(int _number)
    {
        haveFuel -= _number;
        updateInventory.UpdateHUD();
    }
    #endregion

}
