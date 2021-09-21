using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Boomerang", menuName = "Hung/Weapon/Boomerang")]
public class BoomerangWeapon : WeaponBehaviour
{
    public override void OnAttackUpdate(Vector2 direction)
    {
        if (attackTime < AttackCooldown)
        {
            attackTime += Time.fixedDeltaTime;
        }
    }

    public override void OnAttackExit(Vector2 direction)
    {
        if (ReadyToAttack(direction.normalized) <= 0) Weapon.Instance.WeaponBack.SetActive(false);
    }

    protected override void ExtraAttackEnter(Vector2 direction)
    {
        Weapon.Instance.gameObject.SetActive(LeftAmmo > 0);
    }
}
