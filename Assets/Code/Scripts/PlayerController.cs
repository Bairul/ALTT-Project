using UnityEditor.Experimental.GraphView;
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
        fire.performed += FireTriggered;
        fire.Enable();
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

    private void FireTriggered(InputAction.CallbackContext context)
    {
        ExperienceController experienceController = GetComponent<ExperienceController>();
        experienceController.AddExperience(3);
        Debug.Log("Add 3 xp");
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