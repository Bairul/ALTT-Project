using System;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    protected int currentHP = 1;

    void Awake()
    {
        currentHP = playerStats.maxHP;
    }

    public void TakeDamage(int amount)
    {
        currentHP = Math.Max(0, currentHP - amount);
        Debug.Log("Took: " + amount + " DMG, Now: " + currentHP);
        if (currentHP == 0) Debug.Log("DEAD");
    }
}
