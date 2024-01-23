using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;


public class WeaponPickup : MonoBehaviour,IPickup
{
    [SerializeField] private WeaponBaseClass weapon;
    [SerializeField] private Sprite weaponSprite;
    private PlayerWeaponManager weaponManager;
    private SpriteRenderer sprite;

    public event Action OnPickup;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        weaponManager = FindAnyObjectByType<PlayerWeaponManager>();

        sprite.sprite = weaponSprite;
    }
  
    public void PickUp(GameObject obj)
    {
        
        weaponManager.SetPrimairyWeapon(weapon.Create());
        Destroy(gameObject);
    }

    


}
