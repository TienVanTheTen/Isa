using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;


public class WeaponPickup : MonoBehaviour,IPickup
{
    [SerializeField] private WeaponBaseClass weapon;

    public event Action OnPickup;

    private PlayerWeaponManager weaponManager;
    
    private void Start()
    {
        weaponManager = FindAnyObjectByType<PlayerWeaponManager>();
    }
    public void PickUp(GameObject obj)
    { 
        weaponManager.SetPrimairyWeapon(weapon.Create());
        Destroy(gameObject);
    }
}
