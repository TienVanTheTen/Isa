using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BulletPickup : MonoBehaviour,IPickup
{
    [SerializeField]
    private EffectBulletScriptableObject effect;
    [SerializeField]
    private int amountOfBullets;
    [SerializeField]
    private ParticleSystem poof;

    private SpriteRenderer spriteRenderer;
    private Collider2D collider2D;

    
    public event Action OnPickup;
    private void Start()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
        collider2D= GetComponent<Collider2D>();
    }
    public void PickUp(GameObject obj)
    {
        BulletTypeManager manager = obj.GetComponent<BulletTypeManager>();

        if (manager != null)
        {
            manager.AddBullet(effect, amountOfBullets);
        }

        PickupEffect();
    }
    async void PickupEffect()
    {
        poof.Play();
        spriteRenderer.enabled= false;
        collider2D.enabled= false;
        await Task.Delay((int)(300f));
        Destroy(gameObject);
    }
}

