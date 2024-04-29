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

   
