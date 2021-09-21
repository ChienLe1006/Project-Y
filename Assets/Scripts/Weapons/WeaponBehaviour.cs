using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBehaviour : ArmoryBehaviour
{
    [SerializeField] protected float attackSpeed;
    [SerializeField] private float attackCooldown;
    [SerializeField] protected float attackTime = 0;
    [SerializeField] private int maxAmmo;
    [SerializeField] private int leftAmmo;
    [SerializeField] private float reloadingTime;

    public float AttackCooldown { get => attackCooldown; set => attackCooldown = value; }
    public int MaxAmmo { get => maxAmmo;}
    public int LeftAmmo { get => leftAmmo; set => leftAmmo = value; }

    public override void OnGameStart()
    {
        leftAmmo = maxAmmo;        
    }

    public void OnAttackEnter(Vector2 direction)
    {
        AttackCooldown = 1 / attackSpeed;
        attackTime = 0;
        ExtraAttackEnter(direction);
    }

    public abstract void OnAttackUpdate(Vector2 direction);

    public int ReadyToAttack(Vector2 fixedDirection) //Try to commit an attack if ammo is available then return true, else return false
    {
        if (LeftAmmo > 0)
        {
            Cartridge.Instance.ConsumeAmmo(--LeftAmmo);
            ProjectilePool.Instance.Spawn(fixedDirection);
            return LeftAmmo;
        }
        else
        {
            
            return -1;
        }       
    }

    public void Reload()
    {
        leftAmmo = maxAmmo;
    }

    public virtual void OnAttackExit(Vector2 direction)
    {
        //customStop(direction, firingPoint);
    }

    //protected abstract void customStop(Vector2 direction, Vector3 firingPoint);
    protected abstract void ExtraAttackEnter(Vector2 direction);
    
}
