using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManager : MonoBehaviour
{
    public float moveSpeed;
    public float currentHealth;
    public float maxHealth;


    public void ChangeMoveSpeed(float amount)
    {
        moveSpeed += amount;
    }
    public void ChangeMaxHealth(float amount)
    {
        maxHealth += amount;
    }
}