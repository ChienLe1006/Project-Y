using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageShower : Ammo
{
    [SerializeField] private float speed;
    protected override void ExtraLiveAction()
    {
        transform.Translate(Vector3.up * Time.fixedDeltaTime*speed);
    }
}
