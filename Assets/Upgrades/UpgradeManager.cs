using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public List<UpgradeBaseClass> currentUpgrades = new List<UpgradeBaseClass>();

    public PlayerStatManager playerStatManager;
    public BulletTypeManager bulletTypeManager;
    // Start is called before the first frame update
    void Start()
    {
        playerStatManager = FindObjectOfType<PlayerStatManager>();
        bulletTypeManager = FindObjectOfType<BulletTypeManager>();
    }

    public void AddUpgrade(UpgradeBaseClass upgrade)
    {
        currentUpgrades.Add(upgrade);
        upgrade.OnEquip(this);
    }

    public void RemoveUpgrade(UpgradeBaseClass upgrade)
    {
        currentUpgrades.Remove(upgrade);
        upgrade.OnDequip(this);
    }
}
