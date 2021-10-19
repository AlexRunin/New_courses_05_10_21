using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : EatingAnything
{
    private void OnEnable()
    {
        MyPlayerMovement.EatingEvent += EatingEffects;
    }
    private void OnDisable()
    {
        MyPlayerMovement.EatingEvent -= EatingEffects;
    }

    public override void EatingEffects()
    {
        Debug.Log("Eating Banana");
        
    } 
}
