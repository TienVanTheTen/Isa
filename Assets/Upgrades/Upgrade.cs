using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class UpgradeBaseClass : MonoBehaviour
{
    public string Id;

    protected UpgradeManager upgradeManager;
    public void Setup(UpgradeManager upgradeManager)
    {
        this.upgradeManager = upgradeManager;
    }

    //what happens when u equip the upgrade
    public abstract void OnEquip();

    //what happens when u dequip the upgrade
    public abstract void OnDequip();

    //generating ID makes sure that the upgrade can be found in the players upgrade list
    [ContextMenu("GenerateId")]
    public void GenerateId()
    {
        Debug.Log("generated Id");
        Id = Guid.NewGuid().ToString();
        Debug.Log(Id);
    }
}
