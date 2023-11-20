using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPlanet : MonoBehaviour
{
    public GameObject planetTarget;
    public float rotationSpeed;

    private void FixedUpdate()
    {
        LookingToTarget(planetTarget.transform.position, rotationSpeed);
    }


    public void LookingToTarget(Vector3 _targetPosition, float _turnSpeed)
    {
        Quaternion _lookRotation = Quaternion.LookRotation((_targetPosition - transform.position).normalized);

        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * _turnSpeed);
    }

}
