using UnityEngine;

[CreateAssetMenu(fileName = "EffectBulletScriptableObject", menuName = "ScriptableObjects/EffectWeapon")]
public class EffectBulletScriptableObject : ScriptableObject
{
    //list with all the base stats of a bullet type
    public BulletType bulletType;
    public Sprite bulletSprite;
    public float damage;
    public float slowAmount;
    public float slowTime;
    public float damageTickAmount = 1;
    public float damageTickDelay;
    public float velocity;
    public float range;

}
//list of bullettypes that exist in the game
public enum BulletType
{
    none = 0,
    Fire = 1,
    Ice = 2,

}

