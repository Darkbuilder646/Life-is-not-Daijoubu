using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IKFootSolver : MonoBehaviour
{
    [Space]
    [SerializeField] private IKFootSolver oppositeLeg;
    [SerializeField] private LayerMask ground = 0;
    [SerializeField] private GameObject centerRay;
    [SerializeField] private Transform legCenter;
    [SerializeField] private bool isFront;

    [Space]
    [Header("Move Value")]
    [SerializeField] private float legMoveSpeed = 0.5f;


    #region Private
    private float stepdistance = 0.5f;
    private Vector3 currentPosition;
    private Ray ray;
    public bool isMining = false;
    #endregion

    public bool moving {private set; get;} = false;

    private void Start()
    {
        if(!isFront)
        {
            stepdistance = (transform.position - legCenter.position).magnitude * 0.8f;
        }
        else
        {
            stepdistance = 1f;
        }

        currentPosition = transform.position;
    }


    void FixedUpdate()
    {
        //transform.position = currentPosition;
        ray = new Ray(centerRay.transform.position, -centerRay.transform.up);
        if (Physics.Raycast(ray, out RaycastHit hit, 20, ground))
        {
            Vector3 distPos = isFront ? hit.point : legCenter.position;
            float actualDist = (transform.position - distPos).magnitude;

            //Debug.Log("actual dist : " + actualDist + " objet : " + transform.name + " stepdistance : " + stepdistance);

            if ((actualDist > stepdistance && !oppositeLeg.moving) && !moving)
            {
                Vector3 stepVector = hit.point - transform.position;

                StartCoroutine(MoveSpider(hit.point + stepVector * (isFront ? 0.5f : 0.8f), legMoveSpeed));

            }
            else
            {
                if (isMining)
                {
                    transform.position = currentPosition;
                }
                else
                {
                    transform.position = Vector3.Lerp(transform.position, currentPosition, Time.deltaTime * legMoveSpeed * 3);
                }

            }

        }

    }


    IEnumerator MoveSpider(Vector3 _targetPoint, float _Time)
    {
        moving = true;
        float t = 0;
        //centerRay.transform.position = _targetPoint + Vector3.up;

        Vector3 originPoint = transform.position;

        while(true)
        {
            yield return null;
            t += Time.fixedDeltaTime;
            transform.position = Vector3.Lerp(originPoint, _targetPoint, t / _Time);
            if(t > _Time)
            {
                t = _Time;
                transform.position = Vector3.Lerp(originPoint, _targetPoint, t / _Time);
                break;
            }
        }

        currentPosition = _targetPoint;

        moving = false;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(ray);
    }
}
