using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPickup : MonoBehaviour,IPickup
{
    [SerializeField]
    private EffectBulletScriptableObject effect;
    [SerializeField]
    private int amountOfBullets;

    
    public event Action OnPickup;
  
    public void PickUp(GameObject obj)
    {
        BulletTypeManager manager = obj.GetComponent<BulletTypeManager>();

        if (manager != null)
        {
            manager.AddBullet(effect, amountOfBullets);
        }

        Destroy(gameObject);
    }
}

