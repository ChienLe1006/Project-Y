using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Ammo
{
    public enum Partitions
    {
        NORMAL_DAMAGE = 0,
        CRITICAL_DAMAGE = 1
    }

    private System.Random rd = new System.Random();

    [SerializeField] private ProjectileBehaviour projectileBehaviour;

    [SerializeField] private float maxDamage;
    [SerializeField] private float currentDamage;
    [SerializeField] private float criticalChance;
    [SerializeField] private float criticalDamage;
    [SerializeField] private Vector3 collisionOffset;

    public void OnEnable()
    {
        time = LiveTime;
        currentDamage = maxDamage;
        try
        {
            projectileBehaviour.OnStart(this);
        }
        catch
        {

        }
    }

    protected override void ExtraLiveAction()
    {
        try
        {
            projectileBehaviour.OnLive();
        }
        catch
        {

        }
    }

    public float MaxDamage { get => maxDamage; set => maxDamage = value; }
    public float CurrentDamage { get => currentDamage; set => currentDamage = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Terrain")
        {
            CollisionEffectPool.Instance.Spawn(transform.position + collisionOffset);
            ProjectilePool.Instance.BackToPool(transform, Partition);
            try
            {
                projectileBehaviour.OnTerrainCollide();
            }
            catch
            {

            }
        }
        
        else if (collision.tag == "Enemy")
        {
            CollisionEffectPool.Instance.Spawn(transform.position + collisionOffset);
            if (projectileBehaviour == null)
            {
                ProjectilePool.Instance.BackToPool(transform, Partition);
            }
            else
            {
                projectileBehaviour.OnEnemyCollide();
            }
            
            collision.GetComponent<Enemy>().TakeDamage(CurrentDamage);
            //DamageShowerPool.Instance.Spawn(collision.transform.position);
            int partition = (int)Partitions.NORMAL_DAMAGE;
            float damageScale = 1;
            if (rd.Next(0, 100) <= criticalChance) 
            {
                partition = (int)Partitions.CRITICAL_DAMAGE;
                damageScale = criticalDamage / 100;
            }
            DamageShowerPool.Instance.OwnSpawn(collision.transform.position, ((int)(currentDamage*damageScale)).ToString(), partition);
        }
    }
}
