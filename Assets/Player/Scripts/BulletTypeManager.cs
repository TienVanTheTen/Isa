using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Rendering;
using UnityEngine;

public class BulletTypeManager : MonoBehaviour
{
    public EffectBulletScriptableObject currentEffect { private set; get; }
    public Dictionary<EffectBulletScriptableObject, int > EffectListInventory = new Dictionary<EffectBulletScriptableObject, int>();
    public event Action onBulletEffectChanged;
    public int currentBulletEffectIndex = 0;
    

    //adding new effect to inventory
    public void AddBullet(EffectBulletScriptableObject type, int amount)
    {
        if (EffectListInventory.ContainsKey(type))
        {
            //if effect is already in inventory but new bullets need to be added
            EffectListInventory[type] += amount;
        }
        else
        {
            //if a new kind of bullet is picked up
            EffectListInventory.Add(type, amount);

        } 
    }

    //scroll function for switching effects
    public void changeBulletEffectIndex(int amount)
    {
        currentBulletEffectIndex += amount;

        if(currentBulletEffectIndex >= EffectListInventory.Count)
            currentBulletEffectIndex = 0;

        if(currentBulletEffectIndex < 0)
            currentBulletEffectIndex = EffectListInventory.Count -1;
        SetCurrentEffect(currentBulletEffectIndex);
    }

    //set current effect ur using
    public void SetCurrentEffect(int index)
    {
        if (EffectListInventory.Count < index || index < 0)
            return;
        currentEffect = EffectListInventory.ElementAt(index).Key;
        onBulletEffectChanged?.Invoke();
    }

    //remove int of effectinventory
    public void RemoveCountEffect(int amount)
    {
        if(currentEffect!= null)
            EffectListInventory[currentEffect] -= Mathf.Max(0,amount);
    }


    //checking if the current effect ur using has bullets left
    public int AbleToShoot()
    {
        if (currentEffect == null)
            return 0;

        if (EffectListInventory[currentEffect] > 0)
            return EffectListInventory.GetValueOrDefault(currentEffect);

        else
            return 0;
    }
}
