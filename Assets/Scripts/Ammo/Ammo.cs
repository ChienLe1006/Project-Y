using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private float liveTime;
    [SerializeField] protected float time;
    [SerializeField] protected Transform partition;

    public Transform Partition { get => partition; set => partition = value; }
    public float LiveTime { get => liveTime; set => liveTime = value; }

    private void OnEnable()
    {
        time = LiveTime;
    }

    private void FixedUpdate()
    {
        if (time <= 0)
        {
            ProjectilePool.Instance.BackToPool(transform, Partition);
        }
        else
        {
            time -= Time.fixedDeltaTime;
            ExtraLiveAction();
        }
    }

    protected virtual void ExtraLiveAction()
    {

    }
}
