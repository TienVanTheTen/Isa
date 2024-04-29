using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour, IHealable, IDamagable
{
    // event for abstraction
    public event Action<float> OnHealthChanged;

    [SerializeField] private PlayerStatManager playerStatManager;

    private float health;
    private float maxHealth;

    private void Start()
    {
        health = playerStatManager.currentHealth;
        maxHealth = playerStatManager.maxHealth;
    }
    public void AddHealth(float amount)
    {
        health = Mathf.Min(health + amount, maxHealth);
        OnHealthChanged?.Invoke(health);
    }

    public void TakeDamage(float amount)
    {
        health -= Mathf.Max(0, amount);
        OnHealthChanged?.Invoke(health);
        if (health != 0)
            return;
        Destroy(gameObject);
    }
    public void Sethealth(int amount)
    {
        health = amount;
    }
    public float GetCurrentHealth()
    {
        return health;
    }
}

