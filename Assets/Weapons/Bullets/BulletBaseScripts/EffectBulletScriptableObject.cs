using UnityEngine;

[CreateAssetMenu(fileName = "EffectBulletScriptableObject", menuName ="ScriptableObjects/EffectWeapon")]
public class EffectBulletScriptableObject : ScriptableObject
{
   public Sprite BulletSprite;
   public float damage;
   public float slowAmount;
   public float slowTime;
   public float damageTickAmount = 1;
   public float damageTickDelay;
   public float velocity;
   public float range;
}
