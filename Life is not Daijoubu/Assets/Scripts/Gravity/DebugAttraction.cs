using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAttraction : MonoBehaviour
{
    [SerializeField] private ChangeActionMap changeActionMapForest;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Ship"))
        {
            changeActionMapForest.inAttraction = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Ship"))
        {
            changeActionMapForest.inAttraction = false;
        }
    }
}
