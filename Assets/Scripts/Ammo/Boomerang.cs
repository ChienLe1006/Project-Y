using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Boomerang", menuName = "Hung/Projectile/Boomerang")]
public class Boomerang : ProjectileBehaviour
{
    public static int destroyedCount;

    [SerializeField] private float halfTime;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 dir;

    public override void OnGameStart()
    {
        destroyedCount = 0;
    }

    public override void OnStart(Projectile projectile)
    {
        this.projectile = projectile;
        halfTime = Weapon.Instance.WeaponBehaviour.AttackCooldown / 2;
        speed = ProjectilePool.Instance.BulletSpeed;
    }

    public override void OnEnemyCollide()
    {
        
    }

    public override void OnTerrainCollide()
    {
        if (++destroyedCount >= Weapon.Instance.WeaponBehaviour.MaxAmmo)
        {
            Cartridge.Instance.Reload(Weapon.Instance.WeaponBehaviour);
            destroyedCount = 0;
        }     
    }

    public override void OnLive() //Call whenever the bullet is still on the way
    { 
        //Debug.Log(projectile.name); 
        if (halfTime <= 0)
        {
            dir = Weapon.Instance.FiringPoint.position - projectile.transform.position;
            if (dir.magnitude <= 0.5f)
            {
                ProjectilePool.Instance.BackToPool(projectile.transform, projectile.Partition);
                Cartridge.Instance.RestoreAmmo(Weapon.Instance.WeaponBehaviour.LeftAmmo++);
                Weapon.Instance.WeaponBack.SetActive(true);
            }
            else projectile.GetComponent<Rigidbody2D>().velocity = dir.normalized * speed;
        }
        else
        {
            halfTime -= Time.fixedDeltaTime;
        }
    }

    
}

