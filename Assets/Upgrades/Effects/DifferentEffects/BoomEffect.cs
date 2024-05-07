using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEffect : SpecialEffectBaseClass
{
    public override void ExecuteEffect()
    {
        Debug.Log("BOOM");
        StartCoroutine(Timer());
       
    }
    IEnumerator Timer()
    {
        yield return  new WaitForSeconds(4);
        EndEffect();
    }
    public override void Refresh()
    {
        StopAllCoroutines();
        StartCoroutine(Timer());
    }

}
