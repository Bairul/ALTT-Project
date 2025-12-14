using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem; // New Input System

[RequireComponent(typeof(Rigidbody2DMovement))]
[RequireComponent(typeof(HealthController))]

public class PlayerController : MonoBehaviour
{
    public PlayerControls playerControls;
    private InputAction move;
    
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyAttackController attack = collision.gameObject.GetComponent<EnemyAttackController>();
            healthController.TakeDamage(attack.DealDamage());
        }
    }
}