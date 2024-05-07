using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnComunicator : MonoBehaviour
{
    //event that triggers when a bullet spawns
    public static Action<BulletStats> OnBulletSpawn; 
}
