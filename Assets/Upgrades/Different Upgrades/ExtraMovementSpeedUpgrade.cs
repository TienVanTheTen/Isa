using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExtraMovementSpeedUpgrade : UpgradeBaseClass
{

    [SerializeField]
    private float moveSpeed;
    public override void OnEquip(UpgradeManager upgradeManager)
    { 
        upgradeManager.playerStatManager.ChangeMoveSpeed(moveSpeed);
    }

    public override void OnDequip(UpgradeManager upgradeManager)
    {
        upgradeManager.playerStatManager.ChangeMoveSpeed(-moveSpeed);
        Destroy(gameObject);
    }
    public override void WhileEquipped(UpgradeManager upgradeManager)
    {
    }
}
