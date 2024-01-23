using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// interfaces voor abstractie.
public interface IHealable
{
    public void AddHealth(float amount);
}

public interface IDamagable
{
    public void TakeDamage(float amount);
}

public interface IEffectable
{
    public void TakeEffects(EffectBulletScriptableObject effects);
}

public class Health : MonoBehaviour, IHealable, IDamagable
{
    // event for abstraction
    public event Action<float> OnHealthChanged;

    // serialize
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;

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
}

