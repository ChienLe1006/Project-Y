using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Penetration Projectile", menuName = "Hung/Projectile/Penetration Projectile")]
public class PenetrationProjectile : ProjectileBehaviour
{
    public override void OnGameStart()
    {
        
    }

    public override void OnStart(Projectile projectile)
    {
        this.projectile = projectile;
    }

    public override void OnLive()
    {

    }

    public override void OnEnemyCollide()
    {
        
    }

    public override void OnTerrainCollide()
    {
    }

    
}
