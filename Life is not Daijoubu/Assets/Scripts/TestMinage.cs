using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMinage : MonoBehaviour
{
    private bool isOk = false;
    public float minageForce = 1f;

    [ContextMenu("Minage")]
    public void Minage()
    {
        isOk = !isOk;
    }

    private void FixedUpdate()
    {
        if(isOk)
        {
            this.transform.position += this.transform.up * minageForce * Time.deltaTime;
        }
        
    }

}
