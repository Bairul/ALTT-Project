using UnityEngine;

[RequireComponent(typeof(Rigidbody2DMovement), typeof(Collider2D))]
public class CollectibleItem : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 1F;
    [SerializeField] private float collectionRange = 0.5F;

    private GameObject target;
    private Rigidbody2DMovement movementComponent;

    void Awake()
    {
        movementComponent = GetComponent<Rigidbody2DMovement>();
    }

    void Start()
    {
        movementComponent.moveSpeed = moveSpeed;
    }

    void FixedUpdate()
    {
        Vector2 moveDirection = Vector2.zero;

        if (target)
        {
            moveDirection = target.transform.position - transform.position;
            if (moveDirection.sqrMagnitude <= collectionRange * collectionRange)
            {
                OnCollect(target);
                return;
            }
            moveDirection.Normalize();
        }

        movementComponent.Move(moveDirection);
    }

    protected virtual void OnCollect(GameObject collector)
    {
        Destroy(gameObject);
    }

    public void SetTarget(GameObject magnetTarget)
    {
        target = magnetTarget;
    }

    public void ClearTarget()
    {
        target = null;
    }
}
