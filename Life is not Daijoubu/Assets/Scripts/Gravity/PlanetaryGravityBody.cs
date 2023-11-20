using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryGravityBody : MonoBehaviour
{
    public GravityAttractor attractor;
    [SerializeField] private ChangeActionMap changeActionMap;
    private Transform bodyTransform = null;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        bodyTransform = this.transform;
    }

    private void FixedUpdate()
    {
        if(changeActionMap.inAttraction && attractor != null)
        {
            attractor.Attract(bodyTransform, rb);
        }
        
    }

}
