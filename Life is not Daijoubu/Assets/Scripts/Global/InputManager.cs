using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    private PlayerControls playerControls;
    private PlayerInput playerInput;
    private InputActionMap actionMap;
    public UnityEvent pickUp;
    public UnityEvent dismount;
    public UnityEvent pause;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        playerControls = new PlayerControls();
        playerInput = GetComponent<PlayerInput>();
    }

    public static InputManager GetInstance()
    {
        return instance;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }


    #region Action Map
    public InputActionMap GetGoundMap()
    {
        return playerInput.actions.FindActionMap("GroundPlayer");
    }

    public InputActionMap GetSpaceMap()
    {
        return playerInput.actions.FindActionMap("SpacePlayer");
    }

    #endregion

    #region Space Action
    public Vector2 GetSpacePlayerMovement()
    {
        return playerControls.SpacePlayer.Movement.ReadValue<Vector2>();
    }

    public float GetSpacePlayerHover()
    {
        return playerControls.SpacePlayer.Hover.ReadValue<float>();
    }

    public float GetSpacePlayerRoll()
    {
        return playerControls.SpacePlayer.Roll.ReadValue<float>();
    }

    public Vector2 GetSpaceMouseDelta()
    {
        return playerControls.SpacePlayer.Look.ReadValue<Vector2>();
    }

    #endregion

    #region Ground Actions
    public Vector2 GetGroundPlayerMovement()
    {
        return playerControls.GroundPlayer.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetGroundMouseDelta()
    {
        return playerControls.GroundPlayer.Look.ReadValue<Vector2>();
    }

    public float GetJump()
    {
        return playerControls.GroundPlayer.Jump.ReadValue<float>();
    }

    

    #endregion

    #region Global
    public void OnDismountShip()
    {
        dismount.Invoke();
    }
    
    public void OnPickUp()
    {
        pickUp.Invoke();
    }

    public void OnPause()
    {
        pause.Invoke();
    }

    #endregion

}
