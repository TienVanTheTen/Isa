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



    //setting a new current weapon
    public void SetPrimairyWeapon(WeaponBaseClass weapon)
    {
        if (currentWeapon != null)
        {
            currentWeapon.onFired -= Fired;
            Destroy(currentWeapon);
        }
           
        currentWeapon = weapon;
        currentWeapon.onFired += Fired;
    }
    //checking for inputs
    private void Update()
    {
        if (currentWeapon == null)
            return;

        if (Input.GetKey(switchBulletTypeUpKey))
            bulletTypeManager.changeBulletEffectIndex(1);

        if (Input.GetKey(switchBulletTypeDownKey))
            bulletTypeManager.changeBulletEffectIndex(-1);

        if (Input.GetButton("Fire1") && bulletTypeManager.AbleToShoot())
            currentWeapon.Fire(shootingPoint, bulletTypeManager.currentEffect);   


        if (Input.GetKey(reloadKey))
            currentWeapon.Reload();
    }
    //communicate with bulleteffects that 1 charge of the effect has been used
    void Fired()
    {
        bulletTypeManager.RemoveCountEffect(1);
    }
   
}
