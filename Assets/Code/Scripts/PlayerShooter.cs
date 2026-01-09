using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform target;

    [SerializeField] private float projectileMaxMoveSpeed;
    [SerializeField] private float shootRate;
    private float shootTimer;

    [SerializeField] private AnimationCurve trajectoryAnimationCurve;
    [SerializeField] private AnimationCurve axisCorrectionAnimationCurve;
    [SerializeField] private AnimationCurve projectileSpeedAnimationCurve;
    [SerializeField] private float projectileMaxHeight;

    private void Update()
    {
        shootTimer -= Time.deltaTime;
        
        if (shootTimer <= 0)
        {
            shootTimer = shootRate;
            ProjectileController projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<ProjectileController>();
            projectile.InitializeProjectile(target, projectileMaxMoveSpeed, projectileMaxHeight);
            projectile.InitializeAnimationCurves(trajectoryAnimationCurve, axisCorrectionAnimationCurve, projectileSpeedAnimationCurve);
        }
    }
}
