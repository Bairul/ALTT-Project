using System;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    [SerializeField] private EnemyStats enemyStats;
    protected int baseDamage = 1;

    void Awake()
    {
        baseDamage = enemyStats.baseDamage;
    }

    public int DealDamage()
    {
        int calculatedDamage = baseDamage;
        Debug.Log("Dealing: " + calculatedDamage + " DMG");
        return calculatedDamage;
    }
}
