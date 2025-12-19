using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class PlayerMagnetController : MonoBehaviour
{
    [Header("Magnet Settings")]
    [SerializeField] private float magnetRange = 5f;

    private CircleCollider2D magnetTrigger;

    void Awake()
    {
        magnetTrigger = GetComponent<CircleCollider2D>();
        magnetTrigger.radius = magnetRange;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out CollectibleItem item)) return;

        item.SetTarget(gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.TryGetComponent(out CollectibleItem item)) return;

        item.ClearTarget();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, magnetRange);
    }
}
