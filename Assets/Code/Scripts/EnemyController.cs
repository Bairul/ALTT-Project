using UnityEngine;

public class EnemyController : MonoBehaviour
{
    HealthController healthController;

    private void Awake()
    {
        healthController = GetComponent<HealthController>();
    }
}
