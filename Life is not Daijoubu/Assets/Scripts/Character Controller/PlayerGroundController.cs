using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundController : MonoBehaviour
{
    private InputManager inputManager;

    public float moveSpeed = 10f;
    public float lookSpeed = 2f;
    public float jumpForce = 2f;
    public float groundDist = 1.5f;
    public float camRotSpeed = 10f;
    private bool isgrounded = false;
    public LayerMask groundMask;
    private Rigidbody rb;
    private RaycastHit hit;
    public Camera playerCam;
    private Vector3 angleCam;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start() 
    {
        inputManager = InputManager.GetInstance();
    }

    private void Update()
    {
        if(Physics.Raycast(transform.position, -this.transform.up, out hit, groundDist, groundMask))
        {
            isgrounded = true;
        }
        Debug.DrawRay(transform.position, -this.transform.up * groundDist, Color.red, 1f);
    }

    private void FixedUpdate()
    {
        //Récupération des inputs
        Vector2 playerMovement = inputManager.GetGroundPlayerMovement();
        Vector3 movement = new Vector3(playerMovement.x, 0f ,playerMovement.y);
        Vector2 mouseDelta = inputManager.GetGroundMouseDelta();
        float playerJump = inputManager.GetJump();

        //rotation en X
        mouseDelta.x = Mathf.Clamp(mouseDelta.x, -1, 1);
        Quaternion localRotaion = Quaternion.Euler(0f ,mouseDelta.x * lookSpeed, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation * localRotaion, Time.fixedDeltaTime * camRotSpeed);// transform.rotation * localRotaion;

        //rotation en Y
        mouseDelta.y = Mathf.Clamp(mouseDelta.y, -1, 1);
        Quaternion camRotation = Quaternion.Euler(-mouseDelta.y * lookSpeed, 0f, 0f);
        
        

        //Mouvement
        rb.MovePosition(this.transform.position + transform.TransformDirection(movement) * moveSpeed * Time.deltaTime);

        //Jump
        if(playerJump == 1 && isgrounded)
        {
            isgrounded = false;
            rb.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
        }

    }

    
}
