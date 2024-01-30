using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "Pistol", menuName = "ScriptableObjects/Weapons/Pistol")]

public class Pistol : WeaponBaseClass
{
    public override WeaponBaseClass Create()
    {
       return Instantiate(this);
    }
}
