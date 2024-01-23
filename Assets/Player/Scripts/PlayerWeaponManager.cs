using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    [SerializeField] private WeaponBaseClass currentWeapon;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private KeyCode reloadKey;
   
    public void SetPrimairyWeapon(WeaponBaseClass weapon)
    {
        if (currentWeapon != null)
            Destroy(currentWeapon);

        currentWeapon = weapon;
    }
    private void Update()
    {
        if (currentWeapon == null)
            return;

        if (Input.GetButton("Fire1"))
            currentWeapon.Fire(shootingPoint);

        if (Input.GetKey(reloadKey))
            currentWeapon.Reload();
    }
   
}
