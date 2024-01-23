using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public interface IWeapon
{
    void Fire(Transform shootingpos);
    void Reload();

}

public abstract class WeaponBaseClass : ScriptableObject, IWeapon
{
    [SerializeField] private GameObject bulletPrefab;

    public int magCapacity;
    public Sprite sprite;
    public float fireRate;
    public float reloadTime;

    public EffectBulletScriptableObject effectWeapon;

    protected bool isReloading;
    private int ammoCount;
    private float lastShot;

    public abstract WeaponBaseClass Create();

    private void Awake()
    {
        ammoCount = magCapacity;
    }

    public virtual void Fire(Transform shootingPos)
    {
        if (ammoCount == 0 || isReloading)
            return;

        if (Time.time - lastShot < 1 / fireRate) 
            return;

        ammoCount--;
        InstantiateBullets(shootingPos);
        lastShot = Time.time;
    }

    public virtual void Reload()
    {
        if(!isReloading)
            ReloadMagazine(); 
    }
    public virtual void InstantiateBullets(Transform shootingPos)
    {
        var bullet = Instantiate(bulletPrefab, shootingPos.position, shootingPos.rotation);
        bullet.GetComponent<Projectile>().effect = effectWeapon;
    }
    async void ReloadMagazine()
    {
        isReloading = true;
        await Task.Delay((int)(reloadTime * 1000f));
        ammoCount = magCapacity;
        isReloading = false;
    }
}
