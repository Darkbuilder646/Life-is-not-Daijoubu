using UnityEngine;

public class PlayerSpaceController : MonoBehaviour
{
    private InputManager inputManager;
    private float actualF_Speed, actualS_Speed, actualH_Speed, actualR_Speed;
    private Vector2 centerScreen, mouseDist;

    [Space]
    [Header("Player Speed")]
    [SerializeField] private float forwardSpeed = 10f;
    [SerializeField] private float sideSpeed = 10f;
    [SerializeField] private float hoverSpeed = 10f;
    [SerializeField] private float rollSpeed = 10f;
    [SerializeField] private float lookSpeed = 45f;

    [Space]
    [Header("Player Acceleration")]
    [SerializeField] private float forwardAcceleration = 2.5f;
    [SerializeField] private float sideAcceleration = 2.5f;
    [SerializeField] private float hoverAcceleration = 2.5f;
    [SerializeField] private float rollAcceleration = 2.5f;


    private void Start()
    {
        inputManager = InputManager.GetInstance();
        centerScreen = new Vector2 (Screen.width * 0.5f, Screen.height * 0.5f);

        //Cursor.lockState = CursorLockMode.Confined; //A réactiver lors de la version final du jeu
    }

    private void Update()
    {
        //Récupération des inputs
        Vector2 playerMovement = inputManager.GetSpacePlayerMovement();
        float playerHover = inputManager.GetSpacePlayerHover();
        Vector2 mouseDelta = inputManager.GetSpaceMouseDelta();
        float playerRoll = inputManager.GetSpacePlayerRoll();

        //Calcule la distance de la souris par rapport au milieu de l'écran
        mouseDist.x = (mouseDelta.x - centerScreen.x) / centerScreen.x;
        mouseDist.y = (mouseDelta.y - centerScreen.y) / centerScreen.y;
        mouseDist = Vector2.ClampMagnitude(mouseDist, 1f);

        //Set une accéleration / décceleration pour le player
        actualF_Speed = Mathf.Lerp(actualF_Speed, playerMovement.y * forwardSpeed, forwardAcceleration * Time.deltaTime);
        actualS_Speed = Mathf.Lerp(actualS_Speed, playerMovement.x * sideSpeed, sideAcceleration * Time.deltaTime);
        actualH_Speed = Mathf.Lerp(actualH_Speed, playerHover * hoverSpeed, hoverAcceleration * Time.deltaTime);
        actualR_Speed = Mathf.Lerp(actualR_Speed, playerRoll * rollSpeed, rollAcceleration * Time.deltaTime);
        
        //Déplacement & rotation du player
        transform.position += transform.forward * actualF_Speed * Time.deltaTime;
        transform.position += transform.right * actualS_Speed * Time.deltaTime;
        transform.position += transform.up * actualH_Speed * Time.deltaTime;
        transform.Rotate(-mouseDist.y * lookSpeed * Time.deltaTime, mouseDist.x * lookSpeed * Time.deltaTime, actualR_Speed * Time.deltaTime, Space.Self);

    }

}