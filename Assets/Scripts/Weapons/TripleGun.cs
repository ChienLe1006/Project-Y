using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New TripleGun", menuName = "Hung/Weapon/TripleGun")]
public class TripleGun : WeaponBehaviour
{
    [SerializeField] private float angle;
    private float rad;
    private Vector2 dir1;
    private Vector2 dir2;
    public override void OnAttackUpdate(Vector2 direction)
    {
        if (attackTime >= AttackCooldown)
        {
            dir1.x = direction.x * Mathf.Cos(rad) - direction.y * Mathf.Sin(rad);
            dir1.y = direction.x * Mathf.Sin(rad) + direction.y * Mathf.Cos(rad);
            dir2.x = direction.x * Mathf.Cos(-rad) - direction.y * Mathf.Sin(-rad);
            dir2.y = direction.x * Mathf.Sin(-rad) + direction.y * Mathf.Cos(-rad);
            ReadyToAttack(direction.normalized);
            ReadyToAttack(dir1.normalized);
            ReadyToAttack(dir2.normalized);
            attackTime = 0;
        }
        else
        {
            attackTime += Time.fixedDeltaTime;
        }       
    }

    protected override void ExtraAttackEnter(Vector2 direction)
    {
        attackTime = AttackCooldown - 0.2f;
        rad = Mathf.Deg2Rad * angle;
    }
}
