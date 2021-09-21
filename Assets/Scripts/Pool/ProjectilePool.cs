using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : Pool<ProjectilePool>, HavePartition, IWeaponSwap
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Transform firingPoint;

    public float BulletSpeed { get => bulletSpeed;}

    protected override void CustomSpawn(Transform nextBullet, Vector2 poweringDir, Transform parentPartition)
    {
        nextBullet.gameObject.SetActive(true);
        Projectile nextAmmo = nextBullet.GetComponent<Projectile>();
        SetPartition(nextAmmo, parentPartition);
        nextAmmo.CurrentDamage *= poweringDir.magnitude;
        nextBullet.position = firingPoint.position;
        nextBullet.rotation = firingPoint.rotation;
        nextBullet.SetParent(null);
        nextBullet.GetComponent<Rigidbody2D>().velocity = poweringDir * BulletSpeed;
    }

    public void Swap(WeaponInfo info, int index)
    {
        original = info.WeaponBullet;
        bulletSpeed = info.WeaponBulletSpeed;
        PartitionSwap(index);
    }

    public void SetPartition(Ammo ammo, Transform parentPartition)
    {
        ammo.Partition = parentPartition;
    }
}
