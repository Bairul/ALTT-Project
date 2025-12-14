using UnityEngine;
using UnityEngine.InputSystem; // New Input System

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public PlayerControls playerControls;
    private InputAction move;
    
    Rigidbody2DMovement movementComponent;
    Vector2 moveDirection;

    private void Awake()
    {
        movementComponent = GetComponent<Rigidbody2DMovement>();
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    public void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
    }

    public void FixedUpdate()
    {
        movementComponent.Move(moveDirection);
    }
}