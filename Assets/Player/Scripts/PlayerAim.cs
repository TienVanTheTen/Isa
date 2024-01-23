using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField]
    private Transform shootingPoint;
    [SerializeField]
    Animator headAnimation;

    void Update()
    {
        Vector3 mousepos = Input.mousePosition;
        mousepos = Camera.main.ScreenToWorldPoint(mousepos);
        Vector2 direction = new Vector2(mousepos.x - shootingPoint.position.x, mousepos.y - shootingPoint.position.y);
        shootingPoint.up = direction;
        headAnimation.SetFloat("RotationX",direction.x);
        headAnimation.SetFloat("RotationY",direction.y);
    }
}
