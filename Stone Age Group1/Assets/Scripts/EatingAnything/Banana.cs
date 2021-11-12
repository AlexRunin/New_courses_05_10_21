using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Banana : EatingAnything
{
    //[SerializeField] private Image hungryLevel;


    private void OnEnable()
    {
        MyPlayerMovement.EatingEvent += EatingEffects;
    }
    private void OnDisable()
    {
        MyPlayerMovement.EatingEvent -= EatingEffects;
    }

    public override void EatingEffects(GameObject fruit)
    {
        Debug.Log("Eating Banana");
        GameObject.Destroy(fruit);

        if (!attackController.IsHit)
        {
            for (int i = 0; i < health.Length; i++)
            {
                if (health[i].gameObject.activeSelf)
                {
                    continue;
                }
                else
                {
                    health[i].SetActive(true);
                    return;
                }
            }

            hungryLevelCount += 25;
        } 
}
}
