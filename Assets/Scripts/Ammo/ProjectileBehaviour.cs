using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileBehaviour : ArmoryBehaviour
{
    [SerializeField] protected Projectile projectile;

    public abstract void OnStart(Projectile projectile);

    public abstract void OnLive();

    public abstract void OnEnemyCollide();

    public abstract void OnTerrainCollide();
}
