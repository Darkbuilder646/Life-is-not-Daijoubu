using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    public float gravity = 9.81f;
    public void Attract(Transform _body, Rigidbody _rb)
    {
        Vector3 gravityUp = (_body.position - transform.position).normalized;
        Vector3 bodyUp = _body.up;

        _rb.AddForce(gravityUp * (-gravity));

        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * _body.rotation;
        _body.rotation = Quaternion.Slerp(_body.rotation, targetRotation, 50 * Time.fixedDeltaTime);
    }
}
