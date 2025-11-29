using UnityEngine;

public class PlayerController : AEntity {
    Rigidbody2D rgbd2d;
    private Vector2 mvt;
    public int movementSpeed = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
    }

    public override void Move() {
        mvt.x = Input.GetAxisRaw("Horizontal");
        mvt.y = Input.GetAxisRaw("Vertical");
        rgbd2d.linearVelocity = mvt.normalized * movementSpeed;
    }

    // Update is called once per frame
    void Update() {
        Move();
    }
}
