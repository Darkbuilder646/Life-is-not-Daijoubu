using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public class Newton : MonoBehaviour
{
    public GameObject sun;
    private Vector3 sunPos;
    public GameObject planet;
    private Vector3 planetPos;
    public Rigidbody sunRB;
    public Rigidbody planetRB;
    private Vector3 startVelocity = new Vector3 (0f, 0.5f, 0f);


    public Vector3 CalculeteForce()
    {
        sunPos = sun.transform.position;
        planetPos = planet.transform.position;

        float distance = Vector3.Distance(sunPos, planetPos);

        float distanceSqrt = Mathf.Sqrt(distance);

        float G = 6.67f * Mathf.Pow(10, -11);

        float force = (sunRB.mass * planetRB.mass * G) / distanceSqrt;

        Vector3 heading = (sunPos - planetPos);

        Vector3 forceWithDirection = (force * (heading / heading.magnitude));

        return forceWithDirection;

    }

    private void FixedUpdate()
    {
        planetRB.AddForce(startVelocity, ForceMode.Impulse);
        Debug.Log(CalculeteForce());
        planetRB.AddForce(CalculeteForce() * 0.1f, ForceMode.Acceleration);

    }
    
}
