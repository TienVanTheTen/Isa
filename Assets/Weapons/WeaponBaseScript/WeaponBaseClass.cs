using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public interface IWeapon
{
    void Fire(Transform shootingpos,EffectBulletScriptableObject effectBullet);
    void Reload(int amount);

}

public abstract class WeaponBaseClass : ScriptableObject, IWeapon
{
    [SerializeField] private GameObject bulletPrefab;

    
    public event Action onFired;
    public event Action onAmmoChanged;

    public int ammoCount { private set; get; }
    public Sprite sprite;
    public float fireRate;
    public float reloadTime;
    public int magCapacity;
    protected bool isReloading;
    
    private float lastShot;

    public abstract WeaponBaseClass Create();

    private void Awake()
    {
        onAmmoChanged?.Invoke();
    }

    //fire function
    public virtual void Fire(Transform shootingPos,EffectBulletScriptableObject effectBullet)
    {
        if (ammoCount == 0 || isReloading)
            return;

        if (Time.time - lastShot < 1 / fireRate) 
            return;

        ammoCount--;
        InstantiateBullets(shootingPos, effectBullet);
        onAmmoChanged?.Invoke();
        onFired?.Invoke();
        lastShot = Time.time;
    }

    //reload function
    public virtual void Reload(int amount)
    {
        if(!isReloading)
            ReloadMagazine(amount); 
    }
    //instatiate bullet function
    public virtual void InstantiateBullets(Transform shootingPos, EffectBulletScriptableObject effectBullet)
    {
        var bullet = Instantiate(bulletPrefab, shootingPos.position, shootingPos.rotation);
        bullet.GetComponent<Projectile>().effect = effectBullet;
    }
    //reloading after a time amount
    async void ReloadMagazine(int amount)
    {
        isReloading = true;
        await Task.Delay((int)(reloadTime * 1000f));
        ammoCount = Math.Min(amount, magCapacity);
        onAmmoChanged?.Invoke();
        isReloading = false;
    }

    public void ResetAmmoCount()
    {
        ammoCount = 0;
        onAmmoChanged?.Invoke();
    }
}
