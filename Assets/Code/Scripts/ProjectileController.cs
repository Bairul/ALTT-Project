using System;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private ProjectileVisual projectileVisual;
    private Transform target;
    private float moveSpeed;
    private float maxMoveSpeed;
    private float destoryProjectileDistance = 0.5f;

    private AnimationCurve trajectoryAnimationCurve;
    private AnimationCurve axisCorrectionAnimationCurve;
    private AnimationCurve projectileSpeedAnimationCurve;

    private float nextXTrajectoryPosition;
    private float nextPositionXCorrection;
    private float nextYTrajectoryPosition;
    private float nextPositionYCorrection;
    private Vector3 trajectoryStartPoint;
    private float trajectoryMaxRelativeHeight;
    private Vector3 trajectoryRange;

    private Vector3 projectileMoveDir;
    
    private void Start()
    {
        trajectoryStartPoint = transform.position;
    }

    private void Update()
    {
        UpdateProjectilePosition();

        if (Vector3.Distance(transform.position, target.position) < destoryProjectileDistance)
        {
            Destroy(gameObject);
        }
    }

    private void UpdateProjectilePosition()
    {
        trajectoryRange = target.position - trajectoryStartPoint;

        if (Mathf.Abs(trajectoryRange.normalized.x) < Mathf.Abs(trajectoryRange.normalized.y))
        {
            if (trajectoryRange.y < 0) moveSpeed  = -moveSpeed;
            UpdatePositionWithXCurve();
        }
        else
        {
            if (trajectoryRange.x < 0) moveSpeed  = -moveSpeed;
            UpdatePositionWithYCurve();
        }
    }

    private void UpdatePositionWithXCurve()
    {
        float nextPositionY = transform.position.y + moveSpeed * Time.deltaTime;
        float nextPositionYNormalized = (nextPositionY - trajectoryStartPoint.y) / trajectoryRange.y;

        float nextPositionXNormalized = trajectoryAnimationCurve.Evaluate(nextPositionYNormalized);
        nextXTrajectoryPosition = nextPositionXNormalized * trajectoryMaxRelativeHeight;

        float nextPositionXCorrectionNormalized = axisCorrectionAnimationCurve.Evaluate(nextPositionYNormalized);
        nextPositionXCorrection = nextPositionXCorrectionNormalized * trajectoryRange.x;

        if (trajectoryRange.x > 0 && trajectoryRange.y > 0)
        {
            nextXTrajectoryPosition = -nextXTrajectoryPosition;
        }
        if (trajectoryRange.x < 0 && trajectoryRange.y < 0)
        {
            nextXTrajectoryPosition = -nextXTrajectoryPosition;
        }

        float nextPositionX = trajectoryStartPoint.x + nextXTrajectoryPosition + nextPositionXCorrection;

        Vector3 newPosition = new Vector3(nextPositionX, nextPositionY, 0);

        CalculateNextProjectileSpeed(nextPositionYNormalized);
        projectileMoveDir  = newPosition - transform.position;

        transform.position = newPosition;
    }

    private void UpdatePositionWithYCurve()
    {
        float nextPositionX = transform.position.x + moveSpeed * Time.deltaTime;
        float nextPositionXNormalized = (nextPositionX - trajectoryStartPoint.x) / trajectoryRange.x;

        float nextPositionYNormalized = trajectoryAnimationCurve.Evaluate(nextPositionXNormalized);
        nextYTrajectoryPosition = nextPositionYNormalized * trajectoryMaxRelativeHeight;

        float nextPositionYCorrectionNormalized = axisCorrectionAnimationCurve.Evaluate(nextPositionXNormalized);
        nextPositionYCorrection = nextPositionYCorrectionNormalized * trajectoryRange.y;

        float nextPositionY = trajectoryStartPoint.y + nextYTrajectoryPosition + nextPositionYCorrection;

        Vector3 newPosition = new Vector3(nextPositionX, nextPositionY, 0);

        CalculateNextProjectileSpeed(nextPositionXNormalized);
        projectileMoveDir  = newPosition - transform.position;

        transform.position = newPosition;
    }

    private void CalculateNextProjectileSpeed(float nextPositionXNormalized)
    {
        float nextMoveSpeedNormalized = projectileSpeedAnimationCurve.Evaluate(nextPositionXNormalized);
        moveSpeed = nextMoveSpeedNormalized * maxMoveSpeed;
    }

    public void InitializeProjectile(Transform target, float maxMoveSpeed, float trajectoryMaxHeight)
    {
        this.target = target;
        this.maxMoveSpeed = maxMoveSpeed;

        float xDistanceToTarget = target.position.x - transform.position.x;
        trajectoryMaxRelativeHeight = Math.Abs(xDistanceToTarget) * trajectoryMaxHeight;

        projectileVisual.SetTarget(target);
    }

    public void InitializeAnimationCurves(AnimationCurve trajectoryAnimationCurve, AnimationCurve axisCorrectionAnimationCurve, AnimationCurve projectileSpeedAnimationCurve)
    {
        this.trajectoryAnimationCurve = trajectoryAnimationCurve;
        this.axisCorrectionAnimationCurve = axisCorrectionAnimationCurve;
        this.projectileSpeedAnimationCurve = projectileSpeedAnimationCurve; 
    }

    public Vector3 GetProjectileMoveDir()
    {
        return projectileMoveDir;
    }

    public float GetNextXTrajectoryPosition()
    {
        return nextXTrajectoryPosition;
    }

    public float GetNextPositionXCorrection()
    {
        return nextPositionXCorrection;
    }

    public float GetNextYTrajectoryPosition()
    {
        return nextYTrajectoryPosition;
    }

    public float GetNextPositionYCorrection()
    {
        return nextPositionYCorrection;
    }
}


