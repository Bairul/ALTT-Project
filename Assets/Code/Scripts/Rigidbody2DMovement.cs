using UnityEngine;

public class Rigidbody2DMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction)
    {
        rb.linearVelocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    }
}
