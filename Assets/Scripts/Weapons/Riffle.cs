using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Riffle", menuName = "Hung/Weapon/Riffle")]
public class Riffle : WeaponBehaviour
{
    public override void OnAttackUpdate(Vector2 direction)
    {
        if (attackTime >= AttackCooldown)
        {
            if ( ReadyToAttack(direction.normalized) == -1)
            {
                Cartridge.Instance.Reload(this);
            }
            attackTime = 0;
        }
        else
        {
            attackTime += Time.fixedDeltaTime;
        }
    }

    protected override void ExtraAttackEnter(Vector2 direction)
    {
        attackTime = AttackCooldown - 0.1f;
    }
}
