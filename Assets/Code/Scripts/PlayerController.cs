using UnityEngine;
using UnityEngine.InputSystem; // New Input System

[RequireComponent(typeof(Rigidbody2DMovement))]
[RequireComponent(typeof(HealthController))]

public class PlayerController : MonoBehaviour
{
    public PlayerControls playerControls;
    private InputAction move;
    private InputAction fire;
    
    Rigidbody2DMovement movementComponent;
    Vector2 moveDirection;

    HealthController healthController;

    private void Awake()
    {
        movementComponent = GetComponent<Rigidbody2DMovement>();
        healthController = GetComponent<HealthController>();
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += FireTriggered;
    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
    }

    public void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
    }

    public void FixedUpdate()
    {
        movementComponent.Move(moveDirection);
    }

    private void FireTriggered(InputAction.CallbackContext context)
    {
        healthController.TakeDamage(1);     // TESTING: every time you left click, health decreases by 1
    }
}