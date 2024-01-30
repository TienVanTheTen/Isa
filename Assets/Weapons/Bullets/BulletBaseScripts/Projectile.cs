using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;

    public EffectBulletScriptableObject effect;

    private float time = 0f;
    private float timeToLive;
    private SpriteRenderer sprite;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = effect.BulletSprite;
        timeToLive = effect.range / effect.velocity;
    }
    private void Update()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(pos, transform.TransformDirection(Vector2.up), effect.velocity * Time.deltaTime,layerMask);
        if (hit.collider != null)
        {
            transform.position = hit.point;

            IDamagable damage = hit.collider.gameObject.GetComponent<IDamagable>();
            if (damage != null)
            {
                damage.TakeDamage(effect.damage);
            }

            IEffectable effectable = hit.collider.gameObject.GetComponent<IEffectable>();
            if (effectable != null)
            {
                effectable.TakeEffects(effect);
            }

            Die();

        }
        else
        {
            transform.Translate(Vector2.up * effect.velocity * Time.deltaTime);
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
