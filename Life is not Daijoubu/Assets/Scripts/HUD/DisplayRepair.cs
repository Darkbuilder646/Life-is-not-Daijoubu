using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DisplayRepair : MonoBehaviour
{
    [SerializeField] private Canvas popUpRepair = null;
    [SerializeField] private BasicInventory inventory;
    [SerializeField] private SphereCollider shipDetectRepair = null;
    [SerializeField] private BoxCollider shipMountDetect = null;
    [SerializeField] private Transform repairedShipTransform = null;
    private bool isOnDetect = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            popUpRepair.enabled = true;
            isOnDetect = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            popUpRepair.enabled = false;
            isOnDetect = false;
        }
    }

    public void RepairShip()
    {
        if(!isOnDetect) { return; }

        if(inventory.HaveIce >= 12 && inventory.HaveCarbone >= 6 && inventory.HaveFuel >= 10)
        {
            inventory.RemoveIce(12);
            inventory.RemoveCarbone(6);
            inventory.RemoveFuel(10);

            popUpRepair.enabled = false;

            shipDetectRepair.enabled = false;

            StartCoroutine(Ship());
        }
    }

    IEnumerator Ship()
    {
        Tween moveRepairedShip;
        moveRepairedShip = transform.DOMove(repairedShipTransform.position, 1.5f, false).SetEase(Ease.Linear);
        moveRepairedShip = transform.DORotate(repairedShipTransform.rotation.eulerAngles, 1.5f, RotateMode.Fast).SetEase(Ease.Linear);
        yield return moveRepairedShip.WaitForCompletion();

        shipMountDetect.enabled = true;
    }
}
