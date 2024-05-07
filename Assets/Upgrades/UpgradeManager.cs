using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    //list of the equiped upgrades
    public Dictionary<string, UpgradeBaseClass> currentUpgrades = new();

    public PlayerStatManager playerStatManager;
    public BulletTypeManager bulletTypeManager;
 
    private void Start()
    {
        playerStatManager = FindObjectOfType<PlayerStatManager>();
        bulletTypeManager = FindObjectOfType<BulletTypeManager>();
    }

    //Adding upgrade to list
    public void AddUpgrade(UpgradeBaseClass upgrade)
    {
        currentUpgrades.Add(upgrade.Id, upgrade);
        upgrade.Setup(this);
        upgrade.OnEquip();
    }

    //removing upgrade in list
    public void RemoveUpgrade(UpgradeBaseClass upgrade)
    {
        //checking for ID of upgrade
        if (currentUpgrades.ContainsKey(upgrade.Id))
        {
            //removing current upgrade with same ID
            UpgradeBaseClass equipedUpgrade = currentUpgrades[upgrade.Id];
            equipedUpgrade.OnDequip();
            Destroy(equipedUpgrade.gameObject);
            currentUpgrades.Remove(equipedUpgrade.Id);
        }

    }
}
