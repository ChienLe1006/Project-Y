using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEffectPool : Pool<CollisionEffectPool>, HavePartition
{
    protected override void CustomSpawn(Transform nextEffect, Vector2 position, Transform parentPartition)
    {
        SetPartition(nextEffect.GetComponent<Ammo>(), parentPartition);
        nextEffect.gameObject.SetActive(true);
        nextEffect.SetParent(null);
        nextEffect.position = position;        
    }

    public void SetPartition(Ammo ammo, Transform parentPartition)
    {
        ammo.Partition = parentPartition;
    }
}
