using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public interface IWeapon
{
    void Fire(Transform shootingpos,EffectBulletScriptableObject effectBullet);
    void Reload();

}

public abstract class WeaponBaseClass : ScriptableObject, IWeapon
{
    [SerializeField] private GameObject bulletPrefab;

    public event Action onFired;
    public int magCapacity;
    public Sprite sprite;
    public float fireRate;
    public float reloadTime;

    protected bool isReloading;
    private int ammoCount;
    private float lastShot;

    public abstract WeaponBaseClass Create();

    private void Awake()
    {
        ammoCount = magCapacity;
    }

    //fire function
    public virtual void Fire(Transform shootingPos,EffectBulletScriptableObject effectBullet)
    {
        if (ammoCount == 0 || isReloading)
            return;

        if (Time.time - lastShot < 1 / fireRate) 
            return;

        ammoCount--;
        onFired?.Invoke();
        InstantiateBullets(shootingPos, effectBullet);
        lastShot = Time.time;
    }

    //reload function
    public virtual void Reload()
    {
        if(!isReloading)
            ReloadMagazine(); 
    }
    //instatiate bullet function
    public virtual void InstantiateBullets(Transform shootingPos, EffectBulletScriptableObject effectBullet)
    {
        var bullet = Instantiate(bulletPrefab, shootingPos.position, shootingPos.rotation);
        bullet.GetComponent<Projectile>().effect = effectBullet;
    }
    //reloading after a time amount
    async void ReloadMagazine()
    {
        isReloading = true;
        await Task.Delay((int)(reloadTime * 1000f));
        ammoCount = magCapacity;
        isReloading = false;
    }
}
