using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pool<T> : Singleton<T> where T: MonoBehaviour
{
    [SerializeField] protected GameObject original;
    [SerializeField] protected List<Transform> partitions;
    [SerializeField] protected Transform current;
    private int cloneCount;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            partitions.Add(transform.GetChild(i));
        }
        current = partitions[0];    
    }

    public void Spawn(Vector2 data)
    {
        if (current.childCount > 0)
        {
            Transform nextAmmo = current.GetChild(current.childCount - 1);
            CustomSpawn(nextAmmo, data, current);
        }
        else
        {
            CustomSpawn(Init().transform, data, current);
        }
    }

    public void BackToPool(Transform bullet, Transform partition)
    {
        bullet.gameObject.SetActive(false);
        bullet.SetParent(partition);
    }

    public void PartitionSwap(int index)
    {
        current = partitions[index];
    }

    public void SetPartition(int index)
    {
        current = partitions[index];
    }

    protected virtual GameObject Init()
    {
        GameObject obj = Instantiate(original);
        obj.name += "(" + cloneCount++ + ")";
        return obj;
    }

    protected abstract void CustomSpawn(Transform spawnTransform, Vector2 data, Transform partition);

}
