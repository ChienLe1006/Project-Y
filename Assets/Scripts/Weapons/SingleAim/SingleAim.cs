using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Single Aim", menuName = "Hung/Weapon/Single Aim")]
public class SingleAim : WeaponBehaviour
{
    public override void OnAttackUpdate(Vector2 direction)
    {

    }

    public override void OnAttackExit(Vector2 direction)
    {
        

    }

    protected override void ExtraAttackEnter(Vector2 direction)
    {
        
    }
}