using UnityEngine;
using UnityEngine.InputSystem; // New Input System

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;           // Max speed
    public float acceleration = 12f;       // How fast you reach max speed
    public float deceleration = 12f;       // How fast you stop

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 currentVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Input System callback
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = moveInput.normalized * moveSpeed;

        // Accelerate or decelerate depending on input
        if (moveInput.sqrMagnitude > 0.01f)
        {
            currentVelocity = Vector2.Lerp(
                currentVelocity,
                targetVelocity,
                acceleration * Time.fixedDeltaTime
            );
        }
        else
        {
            // Smooth stopping
            currentVelocity = Vector2.Lerp(
                currentVelocity,
                Vector2.zero,
                deceleration * Time.fixedDeltaTime
            );
        }

        rb.linearVelocity = currentVelocity;
    }
}