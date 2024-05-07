using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExtraMovementSpeedUpgrade : UpgradeBaseClass
{

    [SerializeField]
    private float moveSpeed;
    
    public override void OnEquip()
    { 
        upgradeManager.playerStatManager.ChangeMoveSpeed(moveSpeed);
    }

    public override void OnDequip()
    {
        upgradeManager.playerStatManager.ChangeMoveSpeed(-moveSpeed);
    }
}
