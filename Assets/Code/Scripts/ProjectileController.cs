using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Transform target;
    private float moveSpeed;
    private float destoryProjectileDistance = 0.5f;

    private void Update()
    {
        Vector3 moveDirectionNormalized = (target.position - transform.position).normalized;
        transform.position += moveDirectionNormalized * moveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) < destoryProjectileDistance)
        {
            Destroy(gameObject);
        }
    }

    public void InitializeProjectile(Transform target, float moveSpeed)
    {
        Debug.Log("I_Target: " + target);
        this.target = target;
        this.moveSpeed = moveSpeed;
    }
}


