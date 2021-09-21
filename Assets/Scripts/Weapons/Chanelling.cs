using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Chanelling", menuName = "Hung/Weapon/Chanelling")]
public class Chanelling : WeaponBehaviour
{
    [SerializeField] private float thresholdScale;
    [SerializeField] private float minPowerScale;
    
    public override void OnAttackUpdate(Vector2 direction)
    {
        if (attackTime < AttackCooldown)
        {
            attackTime += Time.fixedDeltaTime;
        }
    }

    public override void OnAttackExit(Vector2 direction)
    {
        if (attackTime > AttackCooldown) attackTime = AttackCooldown;
        
        if (attackTime/AttackCooldown >= thresholdScale)
        {
            float percentage = (attackTime / AttackCooldown - thresholdScale) / (1 - thresholdScale);
            float powerScale = minPowerScale + (1 - minPowerScale) * percentage;
            //Debug.Log("S: " + powerScale);
            ReadyToAttack(direction.normalized*powerScale);
        }     
    }

    protected override void ExtraAttackEnter(Vector2 direction)
    {
        Weapon.Instance.Anim.SetFloat("AttackSpeed", attackSpeed);
        if (LeftAmmo <= 0)
        {
            Cartridge.Instance.Reload(this);
        }
    }
}