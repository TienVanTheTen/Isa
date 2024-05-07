using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;

    BulletStats stats;

    private float time = 0f;
    private float timeToLive;
    private SpriteRenderer sprite;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        stats = GetComponent<BulletStats>();
        sprite.sprite = stats.bulletSprite;
        timeToLive = stats.range / stats.velocity;
        BulletSpawnComunicator.OnBulletSpawn?.Invoke(stats);
        
    }
    private void Update()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(pos, transform.TransformDirection(Vector2.up), stats.velocity * Time.deltaTime,layerMask);
        if (hit.collider != null)
        {
            transform.position = hit.point;

            IDamagable damage = hit.collider.gameObject.GetComponent<IDamagable>();
            if (damage != null)
            {
                damage.TakeDamage(stats.damage);
            }

            IEffectable effectable = hit.collider.gameObject.GetComponent<IEffectable>();
            if (effectable != null)
            {
                effectable.TakeEffects(stats);
            }

            ISpecialEffecable specialEffecable = hit.collider.gameObject.GetComponent<ISpecialEffecable>();
            if(specialEffecable != null)
            {
                specialEffecable.TakeSpecialEffects(stats.specialEffects, hit.collider.gameObject);
            }

            Die();

        }
        else
        {
            transform.Translate(Vector2.up * stats.velocity * Time.deltaTime);
        }

        CalculateDecay();
    }

    private void CalculateDecay()
    {
        if (time < timeToLive)
        {
            time += Time.deltaTime;
            return;
        }
        Die();
    }

    private void Die()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        this.enabled = false;
        Destroy(gameObject, 1f);
    }
}
