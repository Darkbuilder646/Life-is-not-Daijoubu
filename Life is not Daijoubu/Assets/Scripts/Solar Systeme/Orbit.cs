using UnityEngine;

public class Orbit : MonoBehaviour 
{

    public float RotationSpeed = 100f;
    public float OrbitSpeed = 50f;
    private float DesiredOrbitDistance;
    public Transform target;

    void Start() 
    {
        DesiredOrbitDistance = Vector3.Distance(target.position, transform.position);
    }

    void FixedUpdate() 
    {
        transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
        transform.RotateAround(target.position, Vector3.up, OrbitSpeed * Time.deltaTime);

        //réajuste le décalage de l'orbit causé par le RotateAround 
        float currentObritDistance = Vector3.Distance(target.position, transform.position);
        Vector3 towardsTarget = transform.position - target.position;

        transform.position += (DesiredOrbitDistance - currentObritDistance) * towardsTarget.normalized;
    }
}
