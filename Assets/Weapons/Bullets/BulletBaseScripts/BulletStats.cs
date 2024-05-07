using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletStats : MonoBehaviour
{   
    //list of special upgrades that the bullet might have
    public List<SpecialEffectBaseClass> specialEffects = new();
    public BulletType type { get; private set; }
    public Sprite bulletSprite { get; private set; }
    public float damage { get; private set; }
    public float slowAmount { get; private set; }
    public float slowTime { get; private set; }
    public float damageTickAmount { get; private set; }
    public float damageTickDelay { get; private set; }
    public float velocity { get; private set; }
    public float range { get; private set; }

   
    //calculating effect of the bullet based on the bullettype it is
    public void CalculateEffect(EffectBulletScriptableObject effect)
    {
        type = effect.bulletType;
        bulletSprite = effect.bulletSprite;
        damage = effect.damage;
        slowAmount = effect.slowAmount;
        slowTime = effect.slowTime;
        damageTickAmount = effect.damageTickAmount;
        damageTickDelay = effect.damageTickDelay;
        velocity = effect.velocity;
        range = effect.range;
    }

    //adding special effect to list
    public void AddSpecialEffect(SpecialEffectBaseClass effect)
    {
        specialEffects.Add(effect);
    }

    //adding more stats \/
    public void AddDamage(float amount)
    {
        damage += amount;
    }
    public void AddSlowAmount(float amount)
    {
        slowAmount += amount;
    }
    public void AddSlowTime(float amount)
    {
        slowTime += amount;
    }
    public void AddDamageTickAmount(float amount)
    {
        damageTickAmount += amount;
    }
    public void SetDamageTickDelay(float amount)
    {
        damageTickDelay = amount;
    }
    public void AddVelocity(float amount)
    {
        velocity += amount;
    }
    public void AddRange(float amount)
    {
        range += amount;
    }
    public void SetRange(float amount)
    {
        range = amount;
    }

}
