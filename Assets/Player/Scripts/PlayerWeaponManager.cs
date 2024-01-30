using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    [SerializeField] private WeaponBaseClass currentWeapon;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private KeyCode reloadKey;
    [SerializeField] private KeyCode switchBulletTypeUpKey;
    [SerializeField] private KeyCode switchBulletTypeDownKey;
    [SerializeField] private BulletTypeManager bulletTypeManager;
    [SerializeField] private UIUpdateAmmoCount updateAmmoCountUI;

    private void Start()
    {
        bulletTypeManager.onBulletEffectChanged += ResetMag;
    }

    //setting a new current weapon
    public void SetPrimairyWeapon(WeaponBaseClass weapon)
    {
        if (currentWeapon != null)
        {
            currentWeapon.onFired -= Fired;
            currentWeapon.onAmmoChanged -= UpdateWeaponUI;
            Destroy(currentWeapon);
        }
           
        currentWeapon = weapon;
        currentWeapon.onFired += Fired;
        currentWeapon.onAmmoChanged += UpdateWeaponUI;
        UpdateWeaponUI();
    }
    //checking for inputs
    private void Update()
    {
        if (currentWeapon == null)
            return;

        if (Input.GetKeyDown(switchBulletTypeUpKey))
            bulletTypeManager.changeBulletEffectIndex(1);

        if (Input.GetKeyDown(switchBulletTypeDownKey))
            bulletTypeManager.changeBulletEffectIndex(-1);

        if (Input.GetButton("Fire1") && bulletTypeManager.AbleToShoot() != 0)
            currentWeapon.Fire(shootingPoint, bulletTypeManager.currentEffect);

        if (Input.GetKey(reloadKey) && bulletTypeManager.AbleToShoot() != 0)
            currentWeapon.Reload(bulletTypeManager.AbleToShoot());
    }
    //communicate with bulleteffects that 1 charge of the effect has been used
    private void Fired()
    {
        Debug.Log(bulletTypeManager.currentEffect);
        if (bulletTypeManager.AbleToShoot() == 0)
        {
            ResetMag();
        }
        bulletTypeManager.RemoveCountEffect(1);
    }
    private void UpdateWeaponUI()
    {
        updateAmmoCountUI.UpdateUI(currentWeapon.ammoCount, currentWeapon.magCapacity);
    }
    private void ResetMag()
    {
        if(currentWeapon == null) 
            return;

        currentWeapon.ResetAmmoCount();
    }
    private void OnDestroy()
    {
        bulletTypeManager.onBulletEffectChanged -= ResetMag;
        currentWeapon.onFired -= Fired;
        currentWeapon.onAmmoChanged -= UpdateWeaponUI;
        Destroy(currentWeapon);
    }


}
