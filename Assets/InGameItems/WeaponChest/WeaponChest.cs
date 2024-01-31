using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TreeEditor;
using UnityEngine;



public class WeaponChest : MonoBehaviour, IDamagable
{
    [SerializeField]
    private GameObject weapon;
    [SerializeField]
    private Transform spawnPos;
    [SerializeField]
    private float CycleWeaponsTime;
    [SerializeField]
    ParticleSystem particleExplosion;
    [SerializeField]
    private List<GameObject> weapons;
    [SerializeField]
    private Material[] whiteFlash;
    
    private Renderer rend;
    private Animator animator;

    private bool opening;
    private void Awake()
    {
        rend = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
        weapon.SetActive(false);
    }
    public void TakeDamage(float amount)
    {
        if(opening)
            return; 
        opening = true;
        WhiteFlash();
        animator.Play("OpenChest");
    }
    public void StartCycle()
    {
        animator.Play("CycleWeapons");
        weapon.SetActive(true);
        CyclingWeapons();
    }
   
    async void CyclingWeapons()
    {
        await Task.Delay((int)(CycleWeaponsTime * 1000f));
        Explode();
    }
    public void PickWeapon()
    {
        if(weapons.Count > 0)
        {
            int randomInt = Random.Range(0, weapons.Count -1);
            Instantiate(weapons[randomInt],spawnPos.position, spawnPos.rotation);
        }  
    }
    public void Explode()
    {
        DestroyImmediate(weapon.gameObject);
        animator.Play("Chest Explode");
    }
    public void PlayParticle()
    {
        particleExplosion.Play();
    }
    public void DestroyChest()
    {
        Destroy(gameObject);
    }
    async void WhiteFlash()
    {
        rend.sharedMaterial = whiteFlash[1];
        await Task.Delay((int)(100f));
        rend.sharedMaterial = whiteFlash[0];

    }
   


}
