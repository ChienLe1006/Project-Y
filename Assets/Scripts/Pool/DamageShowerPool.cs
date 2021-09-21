using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageShowerPool : Pool<DamageShowerPool>, HavePartition
{
    [SerializeField] private List<GameObject> originals;
    [SerializeField] private Vector2 offset;
    [SerializeField] private string message;
    protected override void CustomSpawn(Transform nextDamageShower, Vector2 position, Transform partition)
    {
        nextDamageShower.SetParent(transform.parent);
        nextDamageShower.GetComponent<TMPro.TextMeshProUGUI>().text = message;
        nextDamageShower.gameObject.SetActive(true);
        
        SetPartition(nextDamageShower.GetComponent<Ammo>(), partition);
        nextDamageShower.position = position + offset;
    }

    public void OwnSpawn(Vector2 position, string message, int partitionIndex)
    {
        this.message = message;
        original = originals[partitionIndex];
        current = partitions[partitionIndex];
        Spawn(position);
    }

    protected override GameObject Init()
    {
        return Instantiate(original, transform.parent);
    }

    public void SetPartition(Ammo ammo, Transform parentPartition)
    {
        ammo.Partition = parentPartition;
    }
}
