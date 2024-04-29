using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradeBaseClass : MonoBehaviour
{
    public abstract void OnEquip(UpgradeManager upgradeManager);
    
    public abstract void OnDequip(UpgradeManager upgradeManager);
    public abstract void WhileEquipped (UpgradeManager upgradeManager);
}
